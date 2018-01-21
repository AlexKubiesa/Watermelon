using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Watermelon.Gameplay
{
    class DiscardPile : CardPile, IEnumerable<Card>
    {
        // The rank of the top non-three, or null if no such card exists.
        public CardRank? EffectiveRank =>
            _orientedCards.FirstOrDefault(orientedCard => orientedCard.Card.Rank != CardRank.Three)
                          .Card
                          ?.Rank;

        public DiscardPile() : base()
        {
        }

        public DiscardPile(IEnumerable<Card> cards, CardOrientation orientation) : base(cards, orientation)
        {
        }

        /// <summary>
        /// Adds a card to the discard pile, along with a burn check.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="burn"></param>
        public void PlayCard(Card card, out bool burn)
        {
            AddOneCard(card, CardOrientation.FaceUp);
            Thread.Sleep(Game.ACTION_DELAY);
            burn = TryBurn();
        }

        /// <summary>
        /// Adds cards to the discard pile, along with a burn check.
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="burn"></param>
        public void PlayCards(IEnumerable<Card> cards, out bool burn)
        {
            AddManyCards(cards, CardOrientation.FaceUp);
            Thread.Sleep(Game.ACTION_DELAY);
            burn = TryBurn();
        }

        public IEnumerable<Card> PickUp()
        {
            var cards = TakeAllCards();
            OnCleared(EventArgs.Empty);
            return cards;
        }

        [Obsolete]
        public IEnumerator<Card> GetEnumerator()
        {
            return _orientedCards.Select(orientedCard => orientedCard.Card).GetEnumerator();
        }

        [Obsolete]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _orientedCards.Select(orientedCard => orientedCard.Card).GetEnumerator();
        }

        private bool TryBurn()
        {
            if (!_orientedCards.Any())
            {
                return false;
            }
            else if (_orientedCards.Peek().Card.Rank == CardRank.Ten)
            {
                Burn();
                return true;
            }
            else if (_orientedCards.Count >= 4)
            {
                var topFourCards = _orientedCards.Take(4);
                if (topFourCards.All(x => topFourCards.All(y => x.Card.Rank == y.Card.Rank)))
                {
                    Burn();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void Burn()
        {
            TakeAllCards();
            OnCleared(EventArgs.Empty);
            Thread.Sleep(Game.ACTION_DELAY);
        }

        public event EventHandler Cleared;

        protected virtual void OnCleared(EventArgs e)
        {
            Cleared?.Invoke(this, e);
        }
    }
}
