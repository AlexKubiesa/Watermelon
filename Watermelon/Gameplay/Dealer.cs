using System;
using System.Collections.Generic;
using System.Linq;
using Watermelon.Gameplay.Players;

namespace Watermelon.Gameplay
{
    class Dealer
    {
        private Deck _deck;

        private Queue<Card> _cards;

        public Dealer(Deck deck)
        {
            _deck = deck;
            _cards = new Queue<Card>();
        }

        public void Shuffle()
        {
            var cardsLinkedList = new LinkedList<Card>(_deck);
            var random = new Random();

            while (cardsLinkedList.Any())
            {
                int cardIndex = random.Next(cardsLinkedList.Count);
                Card card = cardsLinkedList.ElementAt(cardIndex);
                cardsLinkedList.Remove(card);
                _cards.Enqueue(card);
            }
        }

        public void Deal(IEnumerable<Player> players, DrawPile drawPile)
        {
            // Deal down cards.
            for (int pileIndex = 0; pileIndex < 3; ++pileIndex)
            {
                foreach (Player p in players)
                {
                    var card = _cards.Dequeue();
                    p.AddDownCard(card, pileIndex);
                }
            }

            // Deal up cards.
            for (int pileIndex = 0; pileIndex < 3; ++pileIndex)
            {
                foreach (Player p in players)
                {
                    var card = _cards.Dequeue();
                    p.AddUpCard(card, pileIndex);
                }
            }

            // Deal into player hands.
            for (int i = 0; i < 3; ++i)
            {
                foreach (Player p in players)
                {
                    var card = _cards.Dequeue();
                    p.AddCardToHand(card);
                }
            }

            // The remaining cards make up the draw pile.
            while (_cards.Any())
            {
                var card = _cards.Dequeue();
                drawPile.Add(card);
            }
        }
    }
}
