using System;
using Z1DataStructAlgorithm.Helper;

namespace Z1DataStructAlgorithm.Stack
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> _front;
        private Node<T> _rear;
        private int _num;

        public LinkedQueue()
        {
            _rear = _front = null;
            _num = 0;
        }

        public int GetLength()
        {
            return _num;
        }

        public bool IsEmpty()
        {
            return (_front == _rear) && _num == 0;
        }

        public bool IsFull()
        {
            return false;
        }

        public IQueue<T> Clear()
        {
            _front = _rear = null;
            _num = 0;
            return this;
        }

        public IQueue<T> In(T item)
        {
            var q = new Node<T>(item);
            if (_rear == null)
            {
                _rear = q;
            }
            else
            {
                _rear.Next = q;
                _rear = q;
            }

            if (_front == null)
                _front = _rear;

            ++_num;

            return this;
        }

        public T Out()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");

            var p = _front;
            _front = _front.Next;
            if (_front == null)
                _rear = null;
            --_num;
            return p.Data;
        }

        public T PeekFront()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return _front.Data;
        }
    }
}