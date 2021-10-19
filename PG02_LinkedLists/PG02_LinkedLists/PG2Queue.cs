using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG02_LinkedLists
{
    public class PG2Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public void Enqueue(T testValue)
        {
            Node<T> node = new Node<T>();
            node.data = testValue;

            if (Count == 0)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.next = node;
                _tail = node;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();                
            }
            else
            {
                T result = _head.data;
                _head = _head.next;
                Count--;

                if (Count == 0)
                {
                    _tail = null;
                }

                return result;
            }            
        }

        public T Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return _head.data;
            }
        }

        public void Reverse()
        {
            Node<T> prev = null;
            Node<T> next = null;

            while (_head != null)
            {
                next = _head.next;
                _head.next = prev;
                prev = _head;
                _head = next;
            }
            _head = prev;
        }
    }
}
