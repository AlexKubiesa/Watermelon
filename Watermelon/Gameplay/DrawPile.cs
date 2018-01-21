using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Watermelon.Gameplay
{
    class DrawPile : CardPile
    {
        public DrawPile() : base()
        {
        }

        public DrawPile(IEnumerable<Card> cards, CardOrientation orientation) : base(cards, orientation)
        {
        }

        public Card Draw()
        {
            return TakeTopCard();
        }

        public void Add(Card card)
        {
            AddOneCard(card, CardOrientation.FaceDown);
        }

        public void AddRange(IEnumerable<Card> cards)
        {
            AddManyCards(cards, CardOrientation.FaceDown);
        }

        public bool Any()
        {
            return _orientedCards.Any();
        }
    }
}