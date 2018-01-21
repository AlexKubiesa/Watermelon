using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watermelon.Gameplay;
using Watermelon.Gameplay.Players;
using Watermelon.Utility;

namespace Watermelon.UI
{
    public partial class ComputerPlayerHandControl : UserControl
    {
        delegate void CardDelegate(Card card);

        public bool AreCardsVisible { get; set; } = false;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => groupBox.Text;
            set
            {
                base.Text = value;
                groupBox.Text = value;
            }
        }

        internal ComputerPlayer Player
        {
            get => player;
            set
            {
                player = value;
                player.AddedCardsToHand += Player_AddedCardsToHand;
                player.PlayedFromHand += Player_PlayedFromHand;
            }
        }

        private ComputerPlayer player;

        private Dictionary<Card, PictureBox> _playerCardsToPictureBoxes;

        internal ComputerPlayerHandControl()
        {
            InitializeComponent();
            _playerCardsToPictureBoxes = new Dictionary<Card, PictureBox>();
        }

        private void AddCard(Card card)
        {
            // Show card in player's hand.
            PictureBox addedCardPictureBox = new PictureBox()
            {
                Image = AreCardsVisible ? card.FrontImage : card.BackImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 58,
                Height = 72
            };
            flowLayoutPanel.Controls.Add(addedCardPictureBox);

            // Add card to dictionary.
            _playerCardsToPictureBoxes.Add(card, addedCardPictureBox);
        }

        private void RemoveCard(Card card)
        {
            // Remove card from player's hand.
            PictureBox removedCardPictureBox = _playerCardsToPictureBoxes[card];
            flowLayoutPanel.Controls.Remove(removedCardPictureBox);

            // Remove card from dictionary.
            _playerCardsToPictureBoxes.Remove(card);
        }

        private void Player_AddedCardsToHand(object sender, CardEventArgs e)
        {
            CardDelegate d = AddCard;

            foreach (var card in e.Cards)
            {
                Invoke(d, card);
            }
        }

        private void Player_PlayedFromHand(object sender, CardEventArgs e)
        {
            CardDelegate d = RemoveCard;

            foreach (var card in e.Cards)
            {
                Invoke(d, card);
            }
        }
    }
}
