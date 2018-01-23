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
            get { return drawPile; }
        }

        public DiscardPile DiscardPile
        {
            get { return discardPile; }
        }

        public IEnumerable<Player> Players => players;

        private GameDifficulty difficulty;

        private DrawPile drawPile;

        private DiscardPile discardPile;

        private List<Player> players;

        private PlayerTurnController turnController;

        public Game(GameSettings settings)
        {
            difficulty = settings.Difficulty;

            drawPile = new DrawPile();
            discardPile = new DiscardPile();
        }

        public void AddPlayers(IEnumerable<Player> players)
        {
            this.players = new List<Player>(players);
            foreach (var player in this.players)
            {
                player.JoinGame(this);
            }

            turnController = new PlayerTurnController(this.players);
        }

        public void Start()
        {
            // Create the deck and dealer.
            var cardFactory = new CardFactory(players.Count);
            var deck = new Deck(cardFactory);
            var dealer = new Dealer(deck);

            // Shuffle and deal the cards.
            dealer.Shuffle();
            dealer.Deal(players, drawPile);

            // Start the game!
            turnController.Start();
        }
    }
}
