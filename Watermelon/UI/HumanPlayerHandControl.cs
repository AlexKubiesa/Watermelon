﻿using System;
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
    public partial class HumanPlayerHandControl : UserControl
    {
        delegate void CardDelegate(Card card);

        public bool AreCardsVisible { get; set; } = true;

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

        internal HumanPlayer Player
        {
            get => player;
            set
            {
                player = value;
                player.AddedCardsToHand += Player_AddedCardsToHand;
                player.PlayedFromHand += Player_PlayedFromHand;
            }
        }

        private HumanPlayer player;

        // Converts between cards in the human player's hand and the corresponding card selection boxes.
        private Bidictionary<CardSelectionBox, Card> _playerCardBoxesToCards;

        internal HumanPlayerHandControl()
        {
            InitializeComponent();
            _playerCardBoxesToCards = new Bidictionary<CardSelectionBox, Card>();
        }

        private void AddCard(Card card)
        {
            // Show card in player's hand.
            var cardSelectionBox = new CardSelectionBox()
            {
                Image = AreCardsVisible ? card.FrontImage : card.BackImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 58,
                Height = 72,
                Cursor = Cursors.Hand,
                Padding = new Padding(4),
                HoverColor = Color.White,
                CheckedColor = Color.Black,
                Enabled = Enabled
            };
            cardSelectionBox.Confirm += CardSelectionBox_Confirm;
            flowLayoutPanel.Controls.Add(cardSelectionBox);

            // Add card to dictionary.
            _playerCardBoxesToCards.Add(cardSelectionBox, card);
        }

        private void RemoveCard(Card card)
        {
            // Remove card from player's hand.
            var removedCardBox = _playerCardBoxesToCards.Reverse(card);
            flowLayoutPanel.Controls.Remove(removedCardBox);

            // Remove card from dictionary.
            _playerCardBoxesToCards.RemoveReverse(card);
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

        private async void CardSelectionBox_Confirm(object sender, SelectionEventArgs e)
        {
            // Try to play all the selected cards.
            // Used ToList() to force evaluation, so that it doesn't fall over later when trying to figure out
            // which cards have been played but GameWindow has removed the relevant information from its
            // dictionary.
            var cards = e.Selection.Cast<CardSelectionBox>().Select(x => _playerCardBoxesToCards.Forward(x)).ToList();
            await Task.Run(() => Player.TryPlayFromHand(cards));
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            foreach (var cardSelectionBox in _playerCardBoxesToCards.Keys)
            {
                cardSelectionBox.Enabled = Enabled;
            }
        }
    }
}