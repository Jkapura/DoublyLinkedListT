using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class LinkedListNode<T>
    {
        public T Value { get; internal set; }
        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Previous { get; internal set; }
        public LinkedListNode(T value)
        { Value = value; }
    }
}
