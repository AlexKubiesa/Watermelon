using System;
using System.Collections.Generic;
using System.Linq;
using Watermelon.Gameplay.Players;
using Watermelon.Utility;

namespace Watermelon.Gameplay
{
    internal class PlayerTurnController
    {
        private CircularDoublyLinkedList<Player> playersLinkedList;

        private ICircularDoublyLinkedListNode<Player> currentPlayerNode;

        public PlayerTurnController(IEnumerable<Player> players)
        {
            playersLinkedList = new CircularDoublyLinkedList<Player>(players);

            foreach (var player in players)
            {
                player.PlayedFromHand += Player_PlayedCards;
                player.PlayedUpCards += Player_PlayedCards;
                player.BlindPlayedDownCard += Player_PlayedCards;
                player.EndedTurn += Player_EndedTurn;
            }

            // Start positioned at the last player, because then we'll move forward and call the first player.
            currentPlayerNode = playersLinkedList.Tail;
        }

        public void Start()
        {
            CallNextPlayer();
        }

        private void Player_PlayedCards(object sender, CardEventArgs e)
        {
            if (e.Cards.First().ReversesTurnOrder)
            {
                ReverseTurnOrder();
            }
        }

        private void Player_EndedTurn(object sender, EventArgs e)
        {
            CallNextPlayer();
        }

        private void CallNextPlayer()
        {
            currentPlayerNode = currentPlayerNode.Next;
            var currentPlayer = currentPlayerNode.Value;
            currentPlayer.BeginTurn();
        }

        private void ReverseTurnOrder()
        {
            playersLinkedList.Reverse();
        }
    }
}
