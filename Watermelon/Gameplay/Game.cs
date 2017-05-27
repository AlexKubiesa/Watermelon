using Watermelon.Gameplay.Players;

namespace Watermelon.Gameplay
{
    public partial class Game
    {
        internal DrawPile DrawPile
        {
            get { return _drawPile; }
        }

        internal DiscardPile DiscardPile
        {
            get { return _discardPile; }
        }

        internal HumanPlayer Player
        {
            get { return _humanPlayer; }
        }

        internal ComputerPlayer ComputerPlayer
        {
            get { return _computerPlayer; }
        }

        private HumanPlayer _humanPlayer;

        private ComputerPlayer _computerPlayer;

        private TurnTracker _turnTracker;

        private DrawPile _drawPile;

        private DiscardPile _discardPile;

        public Game()
        {
            _humanPlayer = new HumanPlayer(this);

            _computerPlayer = new ComputerPlayer(this);

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
