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

        public void Reverse()
        {
            foreach (var node in ToList())
            {
                ReverseNode(node);
            }

            Swap(ref head, ref tail);
        }

        private static void LinkNodes(Node<TValue> first, Node<TValue> second)
        {
            first.Next = second;
            second.Previous = first;
        }

        private static void ReverseNode(Node<TValue> node)
        {
            var newNext = node.Previous;
            node.Previous = node.Next;
            node.Next = newNext;
        }

        private static void Swap<TObject>(ref TObject first, ref TObject second)
        {
            TObject temp = first;
            first = second;
            second = temp;
        }

        public IEnumerator<ICircularDoublyLinkedListNode<TValue>> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<Node<TValue>> ToList()
        {
            var list = new List<Node<TValue>>();

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
