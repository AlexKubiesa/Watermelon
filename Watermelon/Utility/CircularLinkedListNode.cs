using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Utility
{
    class CircularLinkedListNode<T>
    {
        private T _value;

        internal CircularLinkedListNode<T> next;

        internal CircularLinkedListNode(T value)
        {
            _value = value;
        }

        public CircularLinkedListNode<T> Next { get { return next; } }

        public T Value { get { return _value; } }
    }
}
