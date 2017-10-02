using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watermelon.Gameplay;
using Watermelon.Gameplay.Players;
using Watermelon.Utility;

namespace Watermelon.UI
{
    public partial class GameBoard : UserControl
    {
        delegate void CardDelegate(Card card);

        delegate void PictureBoxImageUpdateDelegate(PictureBox box, Image image);

        delegate void VoidDelegate();

#if DEBUG
        private const bool SHOW_COMPUTER_CARDS = true;
#else
        private const bool SHOW_COMPUTER_CARDS = false;
#endif

        internal GameDifficulty GameDifficulty { get => _gameDifficulty; set => _gameDifficulty = value; }

        private GameDifficulty _gameDifficulty;

        private Game _game;

        // Converts between cards in the human player's hand and the corresponding card selection boxes.
        private Bidictionary<CardSelectionBox, Card> _humanCardBoxesToCards;

        private Dictionary<Card, PictureBox> _computerCardPictureBoxes;

        private HumanPlayer _humanPlayer;

        private ComputerPlayer _computerPlayer;

        private CardSelectionBox[] _humanUpDownCardBoxes;

        private List<PictureBox> _computerUpDownCardPictureBoxes;

        private DrawPile DrawPile
        {
            get { return _game.DrawPile; }
        }

        private DiscardPile DiscardPile
        {
            get { return _game.DiscardPile; }
        }

        public GameBoard()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "UI Thread";

            _humanUpDownCardBoxes = new CardSelectionBox[3]
            {
                humanUpDownCardBox1,
                humanUpDownCardBox2,
                humanUpDownCardBox3
            };

            foreach (var box in _humanUpDownCardBoxes)
            {
                box.Confirm += HumanUpDownCardBox_Confirm;
            }

            _computerUpDownCardPictureBoxes = new List<PictureBox>()
            {
                computerUpDownCardPictureBox1,
                computerUpDownCardPictureBox2,
                computerUpDownCardPictureBox3
            };
        }

        public void StartGame()
        {
            _game = new Game(_gameDifficulty);

            DrawPile.ImageUpdated += DrawPile_ImageUpdated;
            DiscardPile.ImageUpdated += DiscardPile_ImageUpdated;

            _humanCardBoxesToCards = new Bidictionary<CardSelectionBox, Card>();
            _computerCardPictureBoxes = new Dictionary<Card, PictureBox>();

            _humanPlayer = _game.HumanPlayer;
            _humanPlayer.ActiveRegionChanged += HumanPlayer_ActiveRegionChanged;
            _humanPlayer.PlayedFromHand += HumanPlayer_PlayedFromHand;
            _humanPlayer.PlayedUpCards += HumanPlayer_PlayedUpCards;
            _humanPlayer.BlindPlayerDownCard += HumanPlayer_PlayedDownCard;
            _humanPlayer.AddedCardsToHand += HumanPlayer_AddedCardsToHand;
            _humanPlayer.AddedUpCard += HumanPlayer_AddedUpCard;
            _humanPlayer.AddedDownCard += HumanPlayer_AddedDownCard;
            _humanPlayer.Won += HumanPlayer_Won;

            _computerPlayer = _game.ComputerPlayer;
            _computerPlayer.PlayedFromHand += ComputerPlayer_PlayedFromHand;
            _computerPlayer.PlayedUpCards += ComputerPlayer_PlayedUpCards;
            _computerPlayer.BlindPlayerDownCard += ComputerPlayer_PlayedDownCard;
            _computerPlayer.AddedCardsToHand += ComputerPlayer_AddedCardsToHand;
            _computerPlayer.AddedUpCard += ComputerPlayer_AddedUpCard;
            _computerPlayer.AddedDownCard += ComputerPlayer_AddedDownCard;
            _computerPlayer.Won += ComputerPlayer_Won;

            _game.Start();
        }

        private void DrawPile_ImageUpdated(object sender, EventArgs e)
        {
            var drawPile = sender as DrawPile;
            PictureBoxImageUpdateDelegate d = delegate (PictureBox box, Image image) { box.Image = image; };
            Invoke(d, drawPilePictureBox, drawPile.Image);
        }

        private void DiscardPile_ImageUpdated(object sender, EventArgs e)
        {
            var discardPile = sender as DiscardPile;
            PictureBoxImageUpdateDelegate d = delegate (PictureBox box, Image image) { box.Image = image; };
            Invoke(d, discardPilePictureBox, discardPile.Image);
        }

        private async void HumanHandCardBox_Confirm(object sender, SelectionEventArgs e)
        {
            // Try to play all the selected cards.
            // Used ToList() to force evaluation, so that it doesn't fall over later when trying to figure out
            // which cards have been played but GameWindow has removed the relevant information from its
            // dictionary.
            var cards = e.Selection.Cast<CardSelectionBox>().Select(x => _humanCardBoxesToCards.Forward(x)).ToList();
            await Task.Run(() => _humanPlayer.TryPlayFromHand(cards));
        }

        private async void HumanUpDownCardBox_Confirm(object sender, SelectionEventArgs e)
        {
            // ToList() prevents lazy evaluation.
            var indices = e.Selection.Select(x => Array.IndexOf(_humanUpDownCardBoxes, x)).ToList();

            var upCards = indices.Select(x => _humanPlayer.UpCards[x]);

            // If the selected cards are all up cards, try and play them.
            if (upCards.All(x => x != null))
            {
                await Task.Run(() => _humanPlayer.TryPlayUpCards(upCards.ToList()));
            }
            // Otherwise, there can't be any up cards for a valid play.
            else if (upCards.All(x => x == null))
            {
                var downCards = indices.Select(x => _humanPlayer.DownCards[x]);

                // Must play exactly one down card.
                if (downCards.Count() == 1 && downCards.First() != null)
                {
                    await Task.Run(() => _humanPlayer.TryBlindPlayDownCard(downCards.First(x => x != null)));
                }
            }
        }

        private void HumanPlayer_ActiveRegionChanged(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateEnabledHumanPlayerCardBoxes;
            Invoke(d);
        }

        private void HumanPlayer_AddedCardsToHand(object sender, CardEventArgs e)
        {
            CardDelegate d = AddToHumanHand;

            foreach (var card in e.Cards)
            {
                Invoke(d, card);
            }
        }

        private void ComputerPlayer_AddedCardsToHand(object sender, CardEventArgs e)
        {
            CardDelegate d = AddToComputerHand;

            foreach (var card in e.Cards)
            {
                Invoke(d, card);
            }
        }

        private void HumanPlayer_AddedUpCard(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateHumanUpDownCardBoxes;
            Invoke(d);
        }

        private void ComputerPlayer_AddedUpCard(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateComputerUpDownCardPictureBoxes;
            Invoke(d);
        }

        private void HumanPlayer_AddedDownCard(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateHumanUpDownCardBoxes;
            Invoke(d);
        }

        private void ComputerPlayer_AddedDownCard(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateComputerUpDownCardPictureBoxes;
            Invoke(d);
        }

        private void HumanPlayer_PlayedFromHand(object sender, CardEventArgs e)
        {
            CardDelegate d = RemoveFromHumanHand;

            foreach (var card in e.Cards)
            {
                Invoke(d, card);
            }
        }

        private void ComputerPlayer_PlayedFromHand(object sender, CardEventArgs e)
        {
            CardDelegate d = RemoveFromComputerHand;

            foreach (var card in e.Cards)
            {
                Invoke(d, card);
            }
        }

        private void HumanPlayer_PlayedUpCards(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateHumanUpDownCardBoxes;
            Invoke(d);
        }

        private void ComputerPlayer_PlayedUpCards(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateComputerUpDownCardPictureBoxes;
            Invoke(d);
        }

        private void HumanPlayer_PlayedDownCard(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateHumanUpDownCardBoxes;
            Invoke(d);
        }

        private void ComputerPlayer_PlayedDownCard(object sender, EventArgs e)
        {
            VoidDelegate d = UpdateComputerUpDownCardPictureBoxes;
            Invoke(d);
        }

        private async void DiscardPilePictureBox_Click(object sender, EventArgs e)
        {
            await Task.Run(() => _humanPlayer.TryPickUp());
        }

        private void HumanPlayer_Won(object sender, EventArgs e)
        {
            MessageBox.Show("You win!");
            Application.Exit();
        }

        private void ComputerPlayer_Won(object sender, EventArgs e)
        {
            MessageBox.Show("You lose. Better luck next time!");
            Application.Exit();
        }

        private void UpdateEnabledHumanPlayerCardBoxes()
        {
            switch (_humanPlayer.ActiveRegion)
            {
                case PlayRegion.Hand:
                    DisableHumanPlayerUpDownCards();
                    EnableHumanPlayerHand();
                    break;

                case PlayRegion.UpCards:
                    DisableHumanPlayerHand();
                    for (int i = 0; i < 3; ++i)
                    {
                        if (_humanPlayer.UpCards[i] != null)
                        {
                            EnableHumanPlayerUpDownCardPile(_humanUpDownCardBoxes[i]);
                        }
                        else
                        {
                            DisableHumanPlayerUpDownCardBox(_humanUpDownCardBoxes[i]);
                        }
                    }
                    break;

                case PlayRegion.DownCards:
                    DisableHumanPlayerHand();
                    for (int i = 0; i < 3; ++i)
                    {
                        if (_humanPlayer.UpCards[i] == null && _humanPlayer.DownCards[i] != null)
                        {
                            EnableHumanPlayerUpDownCardPile(_humanUpDownCardBoxes[i]);
                        }
                        else
                        {
                            DisableHumanPlayerUpDownCardBox(_humanUpDownCardBoxes[i]);
                        }
                    }
                    break;

                case null:
                    DisableHumanPlayerHand();
                    DisableHumanPlayerUpDownCards();
                    break;

                default:
                    DisableHumanPlayerHand();
                    DisableHumanPlayerUpDownCards();
                    break;
            }
        }

        private void DisableHumanPlayerHand()
        {
            foreach (var cardBox in _humanCardBoxesToCards.Keys)
            {
                cardBox.Enabled = false;
            }
        }

        private void DisableHumanPlayerUpDownCardBox(CardSelectionBox box)
        {
            box.Enabled = false;
        }

        private void DisableHumanPlayerUpDownCards()
        {
            foreach (var cardBox in _humanUpDownCardBoxes)
            {
                cardBox.Enabled = false;
            }
        }

        private void EnableHumanPlayerHand()
        {
            foreach (var cardBox in _humanCardBoxesToCards.Keys)
            {
                cardBox.Enabled = true;
            }
        }

        private void EnableHumanPlayerUpDownCardPile(CardSelectionBox box)
        {
            box.Enabled = true;
        }

        private void AddToHumanHand(Card card)
        {
            // Show card in player's hand.
            var addedCardBox = new CardSelectionBox()
            {
                Image = card.FrontImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = drawPilePictureBox.Width - 20,
                Height = playerHandPanel.Height - playerHandPanel.Padding.Vertical - 6,
                Cursor = Cursors.Hand,
                Padding = new Padding(4),
                HoverColor = Color.White,
                CheckedColor = Color.Black
            };
            addedCardBox.Confirm += HumanHandCardBox_Confirm;
            playerHandPanel.Controls.Add(addedCardBox);

            // Add card to dictionary.
            _humanCardBoxesToCards.Add(addedCardBox, card);
        }

        private void AddToComputerHand(Card card)
        {
            // Show card in player's hand.
            PictureBox addedCardPictureBox = new PictureBox()
            {
                Image = SHOW_COMPUTER_CARDS ? card.FrontImage : card.BackImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = drawPilePictureBox.Width,
                Height = computerHandPanel.Height - computerHandPanel.Padding.Vertical - 6
            };
            computerHandPanel.Controls.Add(addedCardPictureBox);

            // Add card to dictionary.
            _computerCardPictureBoxes.Add(card, addedCardPictureBox);
        }

        private void RemoveFromHumanHand(Card card)
        {
            // Remove card from player's hand.
            var removedCardBox = _humanCardBoxesToCards.Reverse(card);
            playerHandPanel.Controls.Remove(removedCardBox);

            // Remove card from dictionary.
            _humanCardBoxesToCards.RemoveReverse(card);
        }

        private void RemoveFromComputerHand(Card card)
        {
            // Remove card from player's hand.
            PictureBox removedCardPictureBox = _computerCardPictureBoxes[card];
            computerHandPanel.Controls.Remove(removedCardPictureBox);

            // Remove card from dictionary.
            _computerCardPictureBoxes.Remove(card);
        }

        private void UpdateHumanUpDownCardBoxes()
        {
            for (int i = 0; i < 3; ++i)
            {
                var upCard = _humanPlayer.UpCards[i];
                var downCard = _humanPlayer.DownCards[i];
                _humanUpDownCardBoxes[i].Image = GetUpDownCardStackedImage(upCard, downCard);
                _humanUpDownCardBoxes[i].Invalidate();
            }
        }

        private void UpdateComputerUpDownCardPictureBoxes()
        {
            for (int i = 0; i < 3; ++i)
            {
                var upCard = _computerPlayer.UpCards[i];
                var downCard = _computerPlayer.DownCards[i];
                _computerUpDownCardPictureBoxes[i].Image = GetUpDownCardStackedImage(upCard, downCard);
            }
        }

        private Image GetUpDownCardStackedImage(Card upCard, Card downCard)
        {
            // If there's no down card, the pile is empty.
            if (downCard == null)
            {
                return null;
            }
            // There's no up card on top of the down card.
            else if (upCard == null)
            {
                return downCard.BackImage;
            }
            // There's an up card to show.
            else
            {
                return upCard.FrontImage;
            }
        }

        internal void ProcessKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CardSelectionBox.UncheckAll();
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            var detailsForm = new GameBoardInformationForm(DiscardPile);
            detailsForm.ShowDialog();
        }
    }
}
