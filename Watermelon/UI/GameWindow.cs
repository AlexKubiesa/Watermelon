using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Watermelon.Utility;
using Watermelon.Gameplay;

namespace Watermelon.UI
{
    public partial class GameWindow : Form
    {
#if DEBUG
        private const bool SHOW_COMPUTER_CARDS = true;
#else
        private const bool SHOW_COMPUTER_CARDS = false;
#endif

        private Game _game;

        // Converts between cards in the human player's hand and the corresponding card selection boxes.
        private Bidictionary<CardSelectionBox, Card> _humanCardBoxesToCards;

        private Dictionary<Card, PictureBox> _computerCardPictureBoxes;

        // update = The UI update; delay = Whether to add a delay.
        private Queue<(MethodInvoker update, bool delay)> _pendingUiUpdates;

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

        public GameWindow()
        {
            InitializeComponent();

            _game = new Game();

            DrawPile.ImageUpdated += DrawPile_ImageUpdated;
            DiscardPile.ImageUpdated += DiscardPile_ImageUpdated;

            _humanCardBoxesToCards = new Bidictionary<CardSelectionBox, Card>();
            _computerCardPictureBoxes = new Dictionary<Card, PictureBox>();
            _pendingUiUpdates = new Queue<(MethodInvoker update, bool delay)>();

            _humanPlayer = _game.Player;
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

        private void GameWindow_Load(object sender, EventArgs e)
        {
            _game.Start();
        }

        private void AddPendingUiUpdate(MethodInvoker invoker, bool delay = true)
        {
            if (!_pendingUiUpdates.Any() && !delay)
            {
                invoker();
            }
            else
            {
                _pendingUiUpdates.Enqueue((invoker, delay));

                if (!gameActionTimer.Enabled)
                {
                    gameActionTimer.Start();
                }
            }
        }

        private void DrawPile_ImageUpdated(object sender, EventArgs e)
        {
            var drawPile = sender as DrawPile;
            drawPilePictureBox.Image = drawPile.Image;
        }

        private void DiscardPile_ImageUpdated(object sender, EventArgs e)
        {
            var discardPile = sender as DiscardPile;
            AddPendingUiUpdate(delegate { discardPilePictureBox.Image = discardPile.Image; }, true);
        }

        private void HumanHandCardBox_Confirm(object sender, SelectionEventArgs e)
        {
            // Try to play all the selected cards.
            // Used ToList() to force evaluation, so that it doesn't fall over later when trying to figure out
            // which cards have been played but GameWindow has removed the relevant information from its
            // dictionary.
            var cards = e.Selection.Cast<CardSelectionBox>().Select(x => _humanCardBoxesToCards.Forward(x)).ToList();
            _humanPlayer.TryPlayFromHand(cards);
        }

        private void HumanUpDownCardBox_Confirm(object sender, SelectionEventArgs e)
        {
            // ToList() prevents lazy evaluation.
            var indices = e.Selection.Select(x => Array.IndexOf(_humanUpDownCardBoxes, x)).ToList();

            // If there's an up card at one of the indices, it must be up cards that we're playing.
            if (_humanPlayer.UpCards[indices[0]] != null)
            {
                _humanPlayer.TryPlayUpCards(indices.Select(x => _humanPlayer.UpCards[x]).ToList());
            }
            // Otherwise, if there's a down card, we must be playing a down card. (NB: Only one!).
            else if (_humanPlayer.DownCards[indices[0]] != null)
            {
                _humanPlayer.TryBlindPlayDownCard(_humanPlayer.DownCards[indices[0]]);
            }
        }

        private void HumanPlayer_AddedCardsToHand(object sender, CardEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                AddToHumanHand(card);
            }
        }

        private void ComputerPlayer_AddedCardsToHand(object sender, CardEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                AddToComputerHand(card);
            }
        }

        private void HumanPlayer_AddedUpCard(object sender, EventArgs e)
        {
            UpdateHumanUpDownCardBoxes();
        }

        private void ComputerPlayer_AddedUpCard(object sender, EventArgs e)
        {
            UpdateComputerUpDownCardPictureBoxes();
        }

        private void HumanPlayer_AddedDownCard(object sender, EventArgs e)
        {
            UpdateHumanUpDownCardBoxes();
        }

        private void ComputerPlayer_AddedDownCard(object sender, EventArgs e)
        {
            UpdateComputerUpDownCardPictureBoxes();
        }

        private void HumanPlayer_PlayedFromHand(object sender, CardEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                RemoveFromHumanHand(card);
            }
        }

        private void ComputerPlayer_PlayedFromHand(object sender, CardEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                RemoveFromComputerHand(card);
            }
        }

        private void HumanPlayer_PlayedUpCards(object sender, EventArgs e)
        {
            UpdateHumanUpDownCardBoxes();
        }

        private void ComputerPlayer_PlayedUpCards(object sender, EventArgs e)
        {
            UpdateComputerUpDownCardPictureBoxes();
        }

        private void HumanPlayer_PlayedDownCard(object sender, EventArgs e)
        {
            UpdateHumanUpDownCardBoxes();
        }

        private void ComputerPlayer_PlayedDownCard(object sender, EventArgs e)
        {
            UpdateComputerUpDownCardPictureBoxes();
        }

        private void DiscardPilePictureBox_Click(object sender, EventArgs e)
        {
            _humanPlayer.TryPickUp();
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

        private void GameActionTimer_Tick(object sender, EventArgs e)
        {
            if (!_pendingUiUpdates.Any())
            {
                gameActionTimer.Stop();
                return;
            }

            {
                var update = _pendingUiUpdates.Dequeue().update;
                update();
            }

            while (_pendingUiUpdates.Any() && !_pendingUiUpdates.Peek().delay)
            {
                var update = _pendingUiUpdates.Dequeue().update;
                update();
            }
        }

        private void AddToHumanHand(Card card)
        {
            // Show card in player's hand.
            var addedCardBox = new CardSelectionBox();
            addedCardBox.Image = card.FrontImage;
            addedCardBox.SizeMode = PictureBoxSizeMode.StretchImage;
            addedCardBox.Width = drawPilePictureBox.Width - 20;
            addedCardBox.Height = playerHandPanel.Height - playerHandPanel.Padding.Vertical - 6;
            addedCardBox.Cursor = Cursors.Hand;
            addedCardBox.Padding = new Padding(4);
            addedCardBox.HoverColor = Color.White;
            addedCardBox.CheckedColor = Color.Black;
            addedCardBox.Confirm += HumanHandCardBox_Confirm;
            playerHandPanel.Controls.Add(addedCardBox);

            // Add card to dictionary.
            _humanCardBoxesToCards.Add(addedCardBox, card);
        }

        private void AddToComputerHand(Card card)
        {
            // Show card in player's hand.
            PictureBox addedCardPictureBox = new PictureBox();
            addedCardPictureBox.Image = SHOW_COMPUTER_CARDS ? card.FrontImage : card.BackImage;
            addedCardPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            addedCardPictureBox.Width = drawPilePictureBox.Width;
            addedCardPictureBox.Height = computerHandPanel.Height - computerHandPanel.Padding.Vertical - 6;
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

#if DEBUG
        #region Code for Testing
        public Game Game
        {
            get { return _game; }
        }
#endregion
#endif

    }
}