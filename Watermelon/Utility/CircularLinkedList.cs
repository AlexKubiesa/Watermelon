using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Utility
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        public T Current
        {
            get { return _current.Value; }
        }

        private CircularLinkedListNode<T> _head;

        private CircularLinkedListNode<T> _current;

        private CircularLinkedListNode<T> _tail;

        public CircularLinkedList()
        {
            _head = null;
            _current = null;
            _tail = null;
        }

        public CircularLinkedList(IList<T> items)
        {
            if (items.Count == 0)
            {
                _head = null;
                _current = null;
                _tail = null;
            }
            else
            {
                _head = new CircularLinkedListNode<T>(items[0]);
                _current = null;

                CircularLinkedListNode<T> previous;
                CircularLinkedListNode<T> current = _head;
                for (int i = 1; i < items.Count; ++i)
                {
                    previous = current;
                    current = new CircularLinkedListNode<T>(items[i]);
                    previous.next = current;
                }
                current.next = _head;
                _tail = current;
            }
        }

        public T Next()
        {
            if (_current == null)
            {
                _current = _head;
                return _current.Value;
            }
            else
            {
                _current = _current.next;
                return _current.Value;
            }
        }

        public void AddLast(T item)
        {
            var newNode = new CircularLinkedListNode<T>(item);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
                newNode.next = newNode;
            }
            else
            {
                _tail.next = newNode;
                newNode.next = _head;
                _tail = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<T> ToList()
        {
            var list = new List<T>();

            var current = _head;
            list.Add(current.Value);
            while (current.next != _head)
            {
                current = current.next;
                list.Add(current.Value);
            }

            return list;
        }
    }
}
