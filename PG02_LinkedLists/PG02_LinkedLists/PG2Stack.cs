using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG02_LinkedLists
{
    public class PG2Stack<T>
    {
        private Node<T> _head;

        public int Count
        {
            get; private set;
        }

        public void Push(T testValue)
        {
            Node<T> node = new Node<T>();
            node.data = testValue;
            node.next = _head;
            _head = node;
            Count++;
        }

        public T Pop()
        {
            try
            {
                T result = _head.data;
                _head = _head.next;
                Count--;

                return result;
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException();
            }            
        }

        public T Peek()
        {
            try
            {
                return _head.data;
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException();
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
