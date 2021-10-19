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

        public void Push(Node<T> testValue)
        {
            Node<T> node = new Node<T>();
            node = testValue;
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

                return _head.data;
            }
            catch (InvalidOperationException)
            {
                throw;
            }            
        }

        public T Peek()
        {
            try
            {
                return _head.data;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        public void Reverse()
        {
            while (_head.next != null)
            {
                Node<T> previousNode = null;
                _head.next = previousNode;
                previousNode = _head;
                _head = _head.next;
            }
        }
    }
}
