using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay.Players
{
    sealed class MediumComputerPlayer : ComputerPlayer
    {
        // Number of cards (except 3 and 10) that the given card can be played on.
        private static Dictionary<CardRank, int> ENTROPIES = new Dictionary<CardRank, int>()
        {
            {CardRank.Ace,   10},
            {CardRank.Eight,  5},
            {CardRank.Five,   4},
            {CardRank.Four,   3},
            {CardRank.Jack,   7},
            {CardRank.King,   9},
            {CardRank.Nine,   6},
            {CardRank.Queen,  8},
            {CardRank.Seven, 11},
            {CardRank.Six,    5},
            {CardRank.Ten,   11},
            {CardRank.Three, 11},
            {CardRank.Two,   11}
        };

        private static int GetEntropy(Card card)
        {
            return ENTROPIES[card.Rank];
        }

        private Random _random;

        public MediumComputerPlayer(Game game) : base(game)
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
                switch (ActiveRegion.Value)
                {
                    // If the player is supposed to know anything about what they're playing...
                    case PlayRegion.Hand:
                        // Choose a playable card with the lowest entropy.
                        var worstCard = playableCards.First(x => playableCards.All(y => GetEntropy(x) <= GetEntropy(y)));

                        // Find all playable cards with the same rank.
                        var worstCardSet = playableCards.Where(x => x.Rank == worstCard.Rank);

                        var cardsToPlay =
                            (!DownCards.Any() && worstCard.IsSpecial && Hand.All(x => worstCardSet.Contains(x)) && worstCardSet.Count() > 1) ?
                            worstCardSet.Where(x => x != worstCard) : // If all special, then play all but one. (Can't win on a special).
                            worstCardSet;                             // Otherwise, just play all of them.

                        // Play the cards.
                        TryPlayFromHand(cardsToPlay);
                        break;

                    case PlayRegion.UpCards:
                        // Choose a playable card with the lowest entropy.
                        worstCard = playableCards.First(x => playableCards.All(y => GetEntropy(x) <= GetEntropy(y)));

                        // Find all playable cards with the same rank.
                        cardsToPlay = playableCards.Where(x => x.Rank == worstCard.Rank);

                        // Play the cards.
                        TryPlayUpCards(cardsToPlay);
                        break;

                    // If the player doesn't know what they're doing...
                    case PlayRegion.DownCards:
                        // Play a random card.
                        var cardToPlay = playableCards[_random.Next(playableCards.Count)];
                        TryBlindPlayDownCard(cardToPlay);
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