using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    // The regions of the game from which the player can play
    enum PlayRegion
    {
        Hand,
        UpCards,
        DownCards
    }

    abstract class Player
    {
        public virtual bool Active
        {
            get { return _active; }
        }

        // The region that the player can currently play from, or null if no such region exists.
        public PlayRegion? ActiveRegion
        {
            get { return _activeRegion; }
        }

        public IReadOnlyList<Card> UpCards
        {
            get { return _upCards; }
        }

        public IReadOnlyList<Card> DownCards
        {
            get { return _downCards; }
        }

        private bool _active;

        private Game _game;

        private List<Card> _hand;

        private Card[] _upCards;

        private Card[] _downCards;

        private PlayRegion? _activeRegion;

        private DrawPile DrawPile
        {
            get { return _game.DrawPile; }
        }

        private DiscardPile DiscardPile
        {
            get { return _game.DiscardPile; }
        }

        public Player(Game game)
        {
            _active = false;
            _game = game;
            _hand = new List<Card>();
            _upCards = new Card[3];
            _downCards = new Card[3];
            _activeRegion = null;
        }

        public void AddCardToHand(Card card)
        {
            AddCardsToHand(new List<Card>() { card });
        }

        public void AddCardsToHand(IEnumerable<Card> cards)
        {
            _hand.AddRange(cards);
            OnAddedCardsToHand(new CardEventArgs(cards));
        }

        public void AddUpCard(Card card, int index)
        {
            _upCards[index] = card;
            OnAddedUpCard(new CardEventArgs(card));
        }

        public void AddDownCard(Card card, int index)
        {
            _downCards[index] = card;
            OnAddedDownCard(new CardEventArgs(card));
        }

        public virtual void BeginTurn()
        {
            _active = true;
            UpdateActiveRegion();
        }

        public void TryPlayFromHand(Card card)
        {
            TryPlayFromHand(new List<Card>() { card });
        }

        public void TryPlayFromHand(IEnumerable<Card> cards)
        {
            // Check if cards all have the same rank.
            if (cards.Any(x => cards.Any(y => (x.Rank != y.Rank))))
            {
                return;
            }
            // Check if card can be played onto the discard pile.
            else if (DiscardPile.EffectiveRank.HasValue &&
                !cards.First().CanBePlayedOn(DiscardPile.EffectiveRank.Value))
            {
                return;
            }
            // Check to make sure the player doesn't win on a special.
            else if (!_downCards.Any(x => x != null) &&
                _hand.Count == 1 &&
                _hand[0].IsSpecial)
            {
                // Pick up the discard pile and end the player's turn.
                var pile = DiscardPile.PickUp();
                _hand.AddRange(pile);
                OnAddedCardsToHand(new CardEventArgs(pile));
                EndTurn();
                return;
            }
            // Play the cards.
            else
            {
                foreach (var c in cards)
                {
                    _hand.Remove(c);
                }
                OnPlayedFromHand(new CardEventArgs(cards));
                DiscardPile.PlayCards(cards, out bool burn);
                while (DrawPile.Any() && _hand.Count < 3)
                {
                    DrawCard();
                }
                // Check if the player has won.
                if (!_downCards.Any(x => x != null) &&
                    !_hand.Any())
                {
                    Win();
                    return;
                }
                UpdateActiveRegion();
                // Player gets an extra turn if they burn; otherwise, their turn ends.
                if (!burn)
                {
                    EndTurn();
                }
            }
        }

        public void TryPlayUpCard(Card card)
        {
            TryPlayUpCards(new List<Card>() { card });
        }

        public void TryPlayUpCards(IEnumerable<Card> cards)
        {
            // Check if you're allowed to play up cards at the moment.
            if (_activeRegion != PlayRegion.UpCards)
            {
                return;
            }
            // Check if cards all have the same rank.
            if (cards.Any(x => cards.Any(y => (x.Rank != y.Rank))))
            {
                return;
            }
            // Check if card can be played onto the discard pile.
            else if (DiscardPile.EffectiveRank.HasValue &&
                !cards.First().CanBePlayedOn(DiscardPile.EffectiveRank.Value))
            {
                return;
            }
            // Play the cards.
            else
            {
                foreach (var c in cards)
                {
                    _upCards[Array.IndexOf(_upCards, c)] = null;
                }
                OnPlayedUpCards(new CardEventArgs(cards));
                DiscardPile.PlayCards(cards, out bool burn);
                while (DrawPile.Any() && _hand.Count < 3)
                {
                    DrawCard();
                }
                UpdateActiveRegion();
                if (!burn)
                {
                    EndTurn();
                }
            }
        }

        public void TryBlindPlayDownCard(Card card)
        {
            // Check if you're allowed to play down cards right now.
            if (_activeRegion != PlayRegion.DownCards)
            {
                return;
            }
            // Check if card can be played onto the discard pile.
            if (DiscardPile.EffectiveRank.HasValue &&
                !card.CanBePlayedOn(DiscardPile.EffectiveRank.Value))
            {
                // Pick up the card, then pick up the discard pile.
                _downCards[Array.IndexOf(_downCards, card)] = null;
                OnBlindPlayedDownCard(new CardEventArgs(card));
                _hand.Add(card);
                OnAddedCardsToHand(new CardEventArgs(card));
                var pile = DiscardPile.PickUp();
                _hand.AddRange(pile);
                OnAddedCardsToHand(new CardEventArgs(pile));
                EndTurn();
                return;
            }
            // Check to make sure player doesn't win on a special.
            else if (_downCards.Count(x => x != null) == 1 &&
                _downCards.Where(x => x != null).First().IsSpecial)
            {
                // Pick up the card, then pick up the discard pile.
                _downCards[Array.IndexOf(_downCards, card)] = null;
                OnBlindPlayedDownCard(new CardEventArgs(card));
                _hand.Add(card);
                OnAddedCardsToHand(new CardEventArgs(card));
                var pile = DiscardPile.PickUp();
                _hand.AddRange(pile);
                OnAddedCardsToHand(new CardEventArgs(pile));
                EndTurn();
                return;
            }
            else
            {
                // Play the card.
                _downCards[Array.IndexOf(_downCards, card)] = null;
                OnBlindPlayedDownCard(new CardEventArgs(card));
                DiscardPile.PlayCard(card, out bool burn);
                while (DrawPile.Any() && _hand.Count < 3)
                {
                    DrawCard();
                }
                if (!_downCards.Any(x => x != null) &&
                    !_hand.Any())
                {
                    Win();
                    return;
                }
                UpdateActiveRegion();
                if (!burn)
                {
                    EndTurn();
                }
            }
        }

        public void TryPickUp()
        {
            if (!_active)
            {
                return;
            }
            else if (_activeRegion.HasValue)
            {
                if (!GetPlayableCards().Any())
                {
                    PickUp();
                }
                return;
            }
            else
            {
                throw new InvalidOperationException("Shouldn't the player have won by now?");
            }
        }

        protected IEnumerable<Card> GetPlayableCards()
        {
            if (!_activeRegion.HasValue)
            {
                return new List<Card>();
            }
            else
            {
                switch (_activeRegion.Value)
                {
                    case PlayRegion.Hand:
                        if (_hand.Count != 1 || !_hand[0].IsSpecial)
                        {
                            // If the player is not left with one special card, normal rules apply.
                            return !DiscardPile.EffectiveRank.HasValue ?
                                _hand :
                                _hand.Where(x => x.CanBePlayedOn(DiscardPile.EffectiveRank.Value));
                        }
                        else
                        {
                            // Otherwise, no available moves, since you can't win on a special card.
                            return new List<Card>();
                        }

                    case PlayRegion.UpCards:
                        // No check here for last card being a special, because it can't happen with up cards.
                        var upCards = _upCards.Where(x => (x != null));
                        return !DiscardPile.EffectiveRank.HasValue ?
                            upCards :
                            upCards.Where(x => x.CanBePlayedOn(DiscardPile.EffectiveRank.Value));
                        
                    case PlayRegion.DownCards:
                        // No check here for last card being a special - still need to try and blind play it.
                        return _downCards.Where(x => (x != null));

                    default:
                        return new List<Card>();
                }
            }
        }

        // This is for the benefit of ComputerPlayer, so that it doesn't need to compute available moves twice.
        protected void PickUp()
        {
            var cards = DiscardPile.PickUp();
            _hand.AddRange(cards);
            OnAddedCardsToHand(new CardEventArgs(cards));
            EndTurn();
        }

        private void DrawCard()
        {
            var card = DrawPile.Draw();
            _hand.Add(card);
            OnAddedCardsToHand(new CardEventArgs(card));
        }

        private void UpdateActiveRegion()
        {
            if (!_active)
            {
                _activeRegion = null;
            }
            else if (_hand.Any())
            {
                _activeRegion = PlayRegion.Hand;
            }
            else if (_upCards.Any(x => x != null))
            {
                _activeRegion = PlayRegion.UpCards;
            }
            else if (_downCards.Any(x => x != null))
            {
                _activeRegion = PlayRegion.DownCards;
            }
            else
            {
                throw new InvalidOperationException("Shouldn't the player have won by now?");
            }
        }

        private void EndTurn()
        {
            _active = false;
            _activeRegion = null;
            OnEndedTurn(EventArgs.Empty);
        }

        private void Win()
        {
            _active = false;
            _activeRegion = null;
            OnWon(EventArgs.Empty);
        }

        protected virtual void OnAddedCardsToHand(CardEventArgs e)
        {
            AddedCardsToHand?.Invoke(this, e);
        }

        protected virtual void OnAddedUpCard(CardEventArgs e)
        {
            AddedUpCard?.Invoke(this, e);
        }

        protected virtual void OnAddedDownCard(CardEventArgs e)
        {
            AddedDownCard?.Invoke(this, e);
        }

        protected virtual void OnPlayedFromHand(CardEventArgs e)
        {
            PlayedFromHand?.Invoke(this, e);
        }

        protected virtual void OnPlayedUpCards(EventArgs e)
        {
            PlayedUpCards?.Invoke(this, e);
        }

        protected virtual void OnBlindPlayedDownCard(EventArgs e)
        {
            BlindPlayerDownCard?.Invoke(this, e);
        }

        protected virtual void OnEndedTurn(EventArgs e)
        {
            EndedTurn?.Invoke(this, e);
        }

        protected virtual void OnWon(EventArgs e)
        {
            Won?.Invoke(this, e);
        }

        public event EventHandler<CardEventArgs> AddedCardsToHand;

        public event EventHandler<CardEventArgs> AddedUpCard;

        public event EventHandler<CardEventArgs> AddedDownCard;

        public event EventHandler<CardEventArgs> PlayedFromHand;

        public event EventHandler PlayedUpCards;

        public event EventHandler BlindPlayerDownCard;

        public event EventHandler EndedTurn;

        public event EventHandler Won;
    }
}
