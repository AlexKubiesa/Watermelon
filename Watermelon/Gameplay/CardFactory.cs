using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    internal class CardFactory
    {
        private int numberOfPlayers;

        public CardFactory(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        public Card CreateCard(CardRank rank, CardSuit suit)
        {
            return new Card(rank, suit)
            {
                IsSpecial = GetIsSpecial(rank),
                ReversesTurnOrder = GetReversesTurnOrder(rank)
            };
        }

        private bool GetIsSpecial(CardRank rank)
        {
            switch (rank)
            {
                case CardRank.Two:
                case CardRank.Three:
                case CardRank.Seven:
                case CardRank.Ten:
                    return true;

                case CardRank.Queen:
                    return numberOfPlayers > 2;

                default:
                    return false;
            }
        }

        private bool GetReversesTurnOrder(CardRank rank)
        {
            return rank == CardRank.Queen && numberOfPlayers > 2;
        }
    }
}
