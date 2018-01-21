using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    internal class CardPile : ICardPile
    {
        public Image Image => _image;

        protected List<(Card Card, CardOrientation Orientation)> _orientedCards;

        private Image _image;

        public CardPile()
        {
            _orientedCards = new List<(Card Card, CardOrientation Orientation)>();
            UpdateImage();
        }

        public CardPile(IEnumerable<Card> cards, CardOrientation orientation)
        {
            _orientedCards = cards.Select(card => (Card: card, Orientation: orientation)).ToList();
            UpdateImage();
        }

        public void AddOneCard(Card card, CardOrientation orientation)
        {
            _orientedCards.Add((Card: card, Orientation: orientation));
            UpdateImage();
        }

        public void AddManyCards(IEnumerable<Card> cards, CardOrientation orientation)
        {
            _orientedCards.AddRange(cards.Select(card => (Card: card, Orientation: orientation)));
            UpdateImage();
        }

        public Card TakeTopCard()
        {
            var card = _orientedCards.Last().Card;
            _orientedCards.RemoveAt(_orientedCards.Count - 1);
            UpdateImage();
            return card;
        }

        public IEnumerable<Card> TakeAllCards()
        {
            var cards = _orientedCards.Select(orientedCard => orientedCard.Card).ToList();
            _orientedCards.Clear();
            UpdateImage();
            return cards;
        }

        private void UpdateImage()
        {
            _image = ComputeNewImage();
            OnImageUpdated(EventArgs.Empty);
        }

        private Image ComputeNewImage()
        {
            if (!_orientedCards.Any())
            {
                return null;
            }

            var topOrientedCard = _orientedCards.Last();
            switch (topOrientedCard.Orientation)
            {
                case CardOrientation.FaceUp:
                    return topOrientedCard.Card.FrontImage;
                case CardOrientation.FaceDown:
                    return topOrientedCard.Card.BackImage;
                default:
                    return null;
            }
        }

        public event EventHandler ImageUpdated;

        protected virtual void OnImageUpdated(EventArgs e)
        {
            ImageUpdated?.Invoke(this, e);
        }
    }
}
