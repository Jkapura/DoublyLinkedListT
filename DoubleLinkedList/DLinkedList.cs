using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    class DLinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            LinkedListNode<T> temp = head;
            head = node;
            head.Next = temp;
            if(Count== 0)
            {
                tail = node;
            }
            else
            {
                temp.Previous = head;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            if(Count == 0)
            {
                head = node;        
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            Count++;            
        }
        public bool Remove(T value)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = head;
            while(current!= null)
            {
                if(current.Value.Equals(value))
                {
                    if(previous!= null)
                    {
                        previous.Next = current.Next;
                        if(current.Next == null)
                        {
                            tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }                    
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public void RemoveFirst()
        {
            if(Count != 0)
            {
                head = head.Next;
                Count--;
                if( Count == 0 )
                {
                    tail = null;
                }
                else
                {
                    head.Previous = null;
                }
            }
        }
        public void RemoveLast()
        {
            if(Count != 0)
            {
                if(Count ==1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail.Previous.Next = null;
                    tail = tail.Previous;
                }
                Count--;
            }
        }
        public bool Contains(T value)
        {
            LinkedListNode<T> current = head;
            while(current!=null)
            {
                if(current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
         }
        public void ClearAll()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = head;
            while(current!= null)
            {
                array[arrayIndex++] = current.Value;
            }
            current = current.Next;
        }
              
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
