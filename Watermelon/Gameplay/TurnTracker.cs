using System;
using System.Collections.Generic;
using System.Linq;
using Watermelon.Gameplay.Players;
using Watermelon.Utility;

namespace Watermelon.Gameplay
{
    class TurnTracker
    {
        public Player ActivePlayer
        {
            get { return _players.Current; }
        }

        // IList, because the players are in a specific order.
        public IList<Player> Players
        {
            get { return _players.ToList(); }
        }

        private CircularLinkedList<Player> _players;

        public TurnTracker()
        {
            _players = new CircularLinkedList<Player>();
        }

        // Only call this method once, and only after all players have been added to the turn tracker.
        public void Start()
        {
            Next();
        }

        public void AddPlayer(Player player)
        {
            _players.AddLast(player);
            player.EndedTurn += Player_EndedTurn;
        }

        private void Player_EndedTurn(object sender, EventArgs e)
        {
            Next();
        }

        private void Next()
        {
            _players.Next();
            ActivePlayer.BeginTurn();
        }
    }
}
