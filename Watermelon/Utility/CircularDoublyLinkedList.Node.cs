using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Utility
{
    public partial class CircularDoublyLinkedList<TValue>
    {
        private class Node<UValue> : ICircularDoublyLinkedListNode<UValue>
        {
            public UValue Value => value;

            ICircularDoublyLinkedListNode<UValue> ICircularDoublyLinkedListNode<UValue>.Next => Next;

            ICircularDoublyLinkedListNode<UValue> ICircularDoublyLinkedListNode<UValue>.Previous => Previous;

            public Node<UValue> Next { get; set; }

            public Node<UValue> Previous { get; set; }

            private UValue value;

            public Node(UValue value)
            {
                this.value = value;
            }
        }
    }
}
