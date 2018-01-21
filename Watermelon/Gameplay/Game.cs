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

        public IEnumerable<Player> Players => _turnTracker.Players;

        private GameDifficulty _difficulty;

        private HumanPlayer _humanPlayer;

        private ComputerPlayer _computerPlayer;

        private TurnTracker _turnTracker;

        private DrawPile _drawPile;

        private DiscardPile _discardPile;

        public Game(GameDifficulty difficulty)
        {
            _difficulty = difficulty;

            _humanPlayer = new HumanPlayer(this);

            _computerPlayer = ComputerPlayer.Create(this);

            _turnTracker = new TurnTracker();
            _turnTracker.AddPlayer(_humanPlayer);
            _turnTracker.AddPlayer(_computerPlayer);

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
            dealer.Deal(_turnTracker.Players, _drawPile);

            // Start the game!
            _turnTracker.Start();
        }
    }
}
