using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Utility
{
    public interface ICircularDoublyLinkedListNode<TValue>
    {
        TValue Value { get; }

        ICircularDoublyLinkedListNode<TValue> Next { get; }

        ICircularDoublyLinkedListNode<TValue> Previous { get; }
    }
}
