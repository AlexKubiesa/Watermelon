using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.ResourceManagement;

namespace Watermelon.Gameplay
{
    public enum CardRank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum CardSuit
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds
    }

    public class Card
    {
        public CardRank Rank => rank;
        public CardSuit Suit => suit;

        public bool IsSpecial { get; set; }
        public bool ReversesTurnOrder { get; set; }

        public Image FrontImage => frontImage;
        public Image BackImage => backImage;

        private readonly CardRank rank;
        private readonly CardSuit suit;

        private Image frontImage;
        private Image backImage;

        /// <summary>
        /// Don't call this directly - use CardFactory.CreateCard instead.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="suit"></param>
        internal Card(CardRank rank, CardSuit suit)
        {
            this.rank = rank;
            this.suit = suit;
            frontImage = CardImageHandler.GetCardImage(rank, suit);
            backImage = CardImageHandler.FaceDownImage;
        }

        public bool? CanBePlayedOn(Card other)
        {
            return CanBePlayedOn(other.Rank);
        }

        public bool CanBePlayedOn(CardRank otherRank)
        {
            if (otherRank == CardRank.Three)
            {
                throw new ArgumentException("Cannot determine whether card playable.");
            }

            // 2, 3, 7, 10 can go on anything.
            switch (Rank)
            {
                case CardRank.Seven:
                case CardRank.Ten:
                case CardRank.Three:
                case CardRank.Two:
                    return true;
            }

            // Anything can go on a 2.
            if (otherRank == CardRank.Two)
            {
                return true;
            }
            // Can play at most a 7 on a 7.
            else if (otherRank == CardRank.Seven)
            {
                return Rank <= CardRank.Seven;
            }
            // This shouldn't ever happen (as tens burn), but just in case, anything can go on a 10.
            else if (otherRank == CardRank.Ten)
            {
                return true;
            }
            // Otherwise, must play same rank or higher.
            else
            {
                return Rank >= otherRank;
            }
        }
    }
}
