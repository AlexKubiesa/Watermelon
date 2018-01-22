﻿using System.Collections.Generic;
using Watermelon.Gameplay.Players;

namespace Watermelon.Gameplay
{
    enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    partial class Game
    {
        public static int ACTION_DELAY { get => 300; }

        public GameDifficulty Difficulty { get => _difficulty; }

        public DrawPile DrawPile
        {
            get { return _drawPile; }
        }

        public DiscardPile DiscardPile
        {
            get { return _discardPile; }
        }

        public HumanPlayer HumanPlayer
        {
            get { return _humanPlayer; }
        }

        public ComputerPlayer ComputerPlayer
        {
            get { return _computerPlayer; }
        }

        public IEnumerable<Player> Players => _players;

        private GameDifficulty _difficulty;

        private HumanPlayer _humanPlayer;

        private ComputerPlayer _computerPlayer;

        private List<Player> _players;

        private PlayerTurnController _turnController;

        private DrawPile _drawPile;

        private DiscardPile _discardPile;

        public Game(GameSettings settings)
        {
            _difficulty = settings.Difficulty;
            _humanPlayer = new HumanPlayer("You", this);

            _computerPlayer = ComputerPlayer.Create("Computer", this);

            _players = new List<Player> { _humanPlayer, _computerPlayer };

            _turnController = new PlayerTurnController(_players);

            _drawPile = new DrawPile();
            _discardPile = new DiscardPile();
        }

        public void Start()
        {
            // Create the deck and dealer.
            var deck = new Deck();
            var dealer = new Dealer(deck);

            // Shuffle and deal the cards.
            dealer.Shuffle();
            dealer.Deal(_players, _drawPile);

            // Start the game!
            _turnController.Start();
        }
    }
}
