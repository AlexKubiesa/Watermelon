using System;
using System.Collections.Generic;
using System.Drawing;

namespace Watermelon.Gameplay
{
    internal enum CardOrientation
    {
        FaceUp,
        FaceDown
    }

    /// <summary>
    /// Represents a pile of cards on the game board, where the top card may be facing up or down. Card piles may be empty.
    /// </summary>
    internal interface ICardPile
    {
        Image Image { get; }

        void AddOneCard(Card card, CardOrientation orientation);

        void AddManyCards(IEnumerable<Card> cards, CardOrientation orientation);

        Card TakeTopCard();

        IEnumerable<Card> TakeAllCards();

        event EventHandler ImageUpdated;
    }
}
