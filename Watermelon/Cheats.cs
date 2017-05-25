#if false

using System.Collections.Generic;
using System.Linq;
using Watermelon.Gameplay;

namespace Watermelon
{
    public partial class Game
    {
        // Replace draw pile with six threes of clubs.
        public void Cheat_ConvertDrawPileToThrees()
        {
            var cardPosition = CardPositionDetails.DrawPile;

            var drawPileCards = new List<Card>()
            {
                new Card(CardRank.Three, CardSuit.Clubs, cardPosition),
                new Card(CardRank.Three, CardSuit.Clubs, cardPosition),
                new Card(CardRank.Three, CardSuit.Clubs, cardPosition),
                new Card(CardRank.Three, CardSuit.Clubs, cardPosition),
                new Card(CardRank.Three, CardSuit.Clubs, cardPosition),
                new Card(CardRank.Three, CardSuit.Clubs, cardPosition),
            };

            while (_drawPile.Any())
            {
                _drawPile.Draw();
            }
            _drawPile.AddRange(drawPileCards);
        }

        // Player pulls a 10 of hearts out of their sleeve.
        public void Cheat_PullATenOutOfSleeve()
        {
            var cardPosition = CardPositionDetails.PlayerHand(_player);
            Card card = new Card(CardRank.Ten, CardSuit.Hearts, cardPosition);
            _player.AddToHand(card);
        }
    }
}

#endif