using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.Gameplay;
using Watermelon.Gameplay.Players;

namespace Watermelon.UI
{
    public class DiscardPileHistoryTracker
    {
        internal IEnumerable<DiscardPileHistoryRecord> History => _history;

        private List<DiscardPileHistoryRecord> _history = new List<DiscardPileHistoryRecord>();

        private DiscardPile _discardPile;

        internal DiscardPileHistoryTracker(DiscardPile discardPile, IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.PlayedFromHand += Player_PlayedCards;
                player.PlayedUpCards += Player_PlayedCards;
                player.BlindPlayedDownCard += Player_PlayedCards;
            }

            _discardPile = discardPile; // ToDo: Hook up burns, pick up, etc.
        }

        private void Player_PlayedCards(object sender, CardEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                _history.Add(new DiscardPileHistoryRecord { Card = card, Player = (Player) sender });
            }
        }
    }
}
