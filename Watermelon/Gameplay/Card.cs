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
        private static bool IsSpecialRank(CardRank rank)
        {
            switch (rank)
            {
                case CardRank.Two:
                case CardRank.Three:
                case CardRank.Seven:
                case CardRank.Ten:
                    return true;

                default:
                    return false;
            }
        }

        public CardRank Rank { get; }

        public CardSuit Suit { get; }

        public bool IsSpecial { get; }

        public Image FrontImage
        {
            get { return _frontImage; }
        }

        public Image BackImage
        {
            get { return _backImage; }
        }

        private Image _frontImage;

        private Image _backImage;

        internal Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
            IsSpecial = IsSpecialRank(rank);
            _frontImage = CardImageHandler.GetCardImage(rank, suit);
            _backImage = CardImageHandler.FaceDownImage;
        }

        internal Card(Card card) : this(card.Rank, card.Suit)
        { }

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
