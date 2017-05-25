using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.Gameplay;

namespace Watermelon.Gameplay
{
    // Represents the entire deck of cards, regardless of where they actually are.
    public class Deck : IReadOnlyList<Card>
    {
        private List<Card> _cards;

        public Deck()
        {
            // Add cards to deck.
            _cards = new List<Card>();

            foreach (var suit in Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>())
            {
                foreach (var rank in Enum.GetValues(typeof(CardRank)).Cast<CardRank>())
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
        }

        #region IReadOnlyList<Card> requirements
        public Card this[int index]
        {
            get { return _cards[index]; }
        }

        public int Count
        {
            get { return _cards.Count; }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cards.GetEnumerator();
        }
        #endregion
    }
}
