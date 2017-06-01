using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Watermelon.Gameplay
{
    class DiscardPile : IEnumerable<Card>
    {
        private Stack<Card> _cards;

        private Image _image;

        public Image Image
        {
            get
            {
                return _image;
            }
        }

        // The rank of the top non-three, or null if no such card exists.
        public CardRank? EffectiveRank
        {
            get
            {
                return _cards.FirstOrDefault(x => x.Rank != CardRank.Three)?.Rank;
            }
        }

        public DiscardPile() : this(new Stack<Card>())
        { }

        public DiscardPile(Stack<Card> cards)
        {
            _cards = cards;
            _image = ComputeImage();
        }

        public void Add(Card card)
        {
            _cards.Push(card);
            UpdateImage();
        }

        public void AddRange(IEnumerable<Card> cards)
        {
            foreach (var c in cards)
            {
                _cards.Push(c);
            }
            UpdateImage();
        }

        /// <summary>
        /// Adds a card to the discard pile, along with a burn check.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="burn"></param>
        public void PlayCard(Card card, out bool burn)
        {
            Add(card);
            Thread.Sleep(300);
            burn = TryBurn();
        }

        /// <summary>
        /// Adds cards to the discard pile, along with a burn check.
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="burn"></param>
        public void PlayCards(IEnumerable<Card> cards, out bool burn)
        {
            AddRange(cards);
            Thread.Sleep(300);
            burn = TryBurn();
        }

        public IEnumerable<Card> PickUp()
        {
            var cards = _cards;
            _cards = new Stack<Card>();
            UpdateImage();
            return cards;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)_cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)_cards).GetEnumerator();
        }

        private bool TryBurn()
        {
            if (!_cards.Any())
            {
                return false;
            }
            else if (_cards.Peek().Rank == CardRank.Ten)
            {
                Burn();
                return true;
            }
            else if (_cards.Count >= 4)
            {
                var topFourCards = _cards.Take(4);
                if (topFourCards.All(x => topFourCards.All(y => x.Rank == y.Rank)))
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
            _cards.Clear();
            UpdateImage();
            Thread.Sleep(300);
        }

        private Image ComputeImage()
        {
            return _cards.Any() ? _cards.Peek().FrontImage : null;
        }

        private void UpdateImage()
        {
            _image = ComputeImage();
            OnImageUpdated(EventArgs.Empty);
        }

        public event EventHandler ImageUpdated;

        protected virtual void OnImageUpdated(EventArgs e)
        {
            ImageUpdated?.Invoke(this, e);
        }
    }
}
