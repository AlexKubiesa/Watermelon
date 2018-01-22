using System;
using System.Collections.Generic;
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

        public GameDifficulty Difficulty { get => difficulty; }

        public DrawPile DrawPile
        {
            get { return _drawPile; }
        }

        public DiscardPile DiscardPile
        {
            get { return _discardPile; }
        }

        public IEnumerable<Player> Players => _players;

        private GameDifficulty difficulty;

        private PlayerTurnController _turnController;

        private DrawPile _drawPile;

        private DiscardPile _discardPile;

        private List<Player> _players;

        public Game(GameSettings settings)
        {
            difficulty = settings.Difficulty;

            _turnController = new PlayerTurnController(_players);

            _drawPile = new DrawPile();
            _discardPile = new DiscardPile();
        }

        public void AddPlayers(IEnumerable<Player> players)
        {
            _players = new List<Player>(players);
            foreach (var player in _players)
            {
                player.JoinGame(this);
            }
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
