using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    class ComputerPlayer : Player
    {
        private Random _random;

        public ComputerPlayer(Game game) : base(game)
        {
            _random = new Random();
        }

        public override void BeginTurn()
        {
            base.BeginTurn();

            // Compute playable cards. If there are none, pick up the discard pile.
            var playableCards = GetPlayableCards().ToList();
            if (!playableCards.Any())
            {
                PickUp();
            }

            while (Active)
            {
                // Choose a random card to play.
                var card = playableCards[_random.Next(playableCards.Count)];

                // Play the card.
                switch (ActiveRegion.Value)
                {
                    case PlayRegion.Hand:
                        TryPlayFromHand(card);
                        break;

                    case PlayRegion.UpCards:
                        TryPlayUpCard(card);
                        break;

                    case PlayRegion.DownCards:
                        TryBlindPlayDownCard(card);
                        break;

                    default:
                        break;
                }

                // If the player's turn has ended, then get out of here.
                if (!Active)
                {
                    return;
                }

                // If there is another move to make, calculate available moves again.
                playableCards = GetPlayableCards().ToList();
            }
        }
    }
}
