using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    class CardEventArgs : EventArgs
    {
        public IEnumerable<Card> Cards { get; }

        public CardEventArgs(Card card) : this(new List<Card>() { card })
        { }

        public CardEventArgs(IEnumerable<Card> cards)
        {
            Cards = cards;
        }
    }
}
