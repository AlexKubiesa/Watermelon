using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Watermelon.Gameplay
{
    class DrawPile : IEnumerable<Card>
    {
        private Stack<Card> _cards;

        private Image _image;

        public Image Image
        {
            get
            {
                return _image;
            }
        }

        public DrawPile() : this(new Stack<Card>())
        { }

        public DrawPile(Stack<Card> cards)
        {
            _cards = cards;
            _image = ComputeImage();
        }

        public Card Draw()
        {
            var result = _cards.Pop();
            UpdateImage();
            return result;
        }

        public void Add(Card card)
        {
            _cards.Push(card);
            UpdateImage();
        }

        public void AddRange(IEnumerable<Card> cards)
        {
            foreach (var c in cards)
            {
                _cards.Push(c);
            }
            UpdateImage();
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)_cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)_cards).GetEnumerator();
        }

        private Image ComputeImage()
        {
            return _cards.Any() ? _cards.Peek().BackImage : null;
        }

        private void UpdateImage()
        {
            _image = ComputeImage();
            OnImageUpdated(EventArgs.Empty);
        }

        public event EventHandler ImageUpdated;

        protected virtual void OnImageUpdated(EventArgs e)
        {
            ImageUpdated?.Invoke(this, e);
        }
    }
}