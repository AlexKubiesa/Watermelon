using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Utility
{
    public partial class CircularDoublyLinkedList<TValue> : IEnumerable<ICircularDoublyLinkedListNode<TValue>>
    {
        public ICircularDoublyLinkedListNode<TValue> Head => head;

        public ICircularDoublyLinkedListNode<TValue> Tail => tail;

        private Node<TValue> head;

        private Node<TValue> tail;

        public CircularDoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        public CircularDoublyLinkedList(IEnumerable<TValue> items) : this()
        {
            foreach (var item in items)
            {
                AddLast(item);
            }
        }

        public ICircularDoublyLinkedListNode<TValue> AddLast(TValue item)
        {
            var newNode = new Node<TValue>(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                LinkNodes(newNode, newNode);
            }
            else
            {
                LinkNodes(tail, newNode);
                LinkNodes(newNode, head);
                tail = newNode;
            }

            return newNode;
        }

        private void LinkNodes(Node<TValue> first, Node<TValue> second)
        {
            first.Next = second;
            second.Previous = first;
        }

        public IEnumerator<ICircularDoublyLinkedListNode<TValue>> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<ICircularDoublyLinkedListNode<TValue>> ToList()
        {
            var list = new List<ICircularDoublyLinkedListNode<TValue>>();

            var current = head;
            list.Add(current);
            while (!current.Next.Equals(head))
            {
                current = current.Next;
                list.Add(current);
            }

            return list;
        }
    }
}
