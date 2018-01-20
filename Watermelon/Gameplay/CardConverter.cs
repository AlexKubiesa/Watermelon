using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    internal class CardConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType.Equals(typeof(string)))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType.Equals(typeof(string)))
            {
                var card = value as Card;
                return ConvertRankToString(card.Rank) + " " + ConvertSuitToString(card.Suit);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        private string ConvertRankToString(CardRank rank)
        {
            switch (rank)
            {
                case CardRank.Ace: return "A";
                case CardRank.Two: return "2";
                case CardRank.Three: return "3";
                case CardRank.Four: return "4";
                case CardRank.Five: return "5";
                case CardRank.Six: return "6";
                case CardRank.Seven: return "7";
                case CardRank.Eight: return "8";
                case CardRank.Nine: return "9";
                case CardRank.Ten: return "10";
                case CardRank.Jack: return "J";
                case CardRank.Queen: return "Q";
                case CardRank.King: return "K";
                default: return "?";
            };
        }

        private string ConvertSuitToString(CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Hearts: return "♥";
                case CardSuit.Diamonds: return "♦";
                case CardSuit.Clubs: return "♣";
                case CardSuit.Spades: return "♠";
                default: return "?";
            }
        }
    }
}
