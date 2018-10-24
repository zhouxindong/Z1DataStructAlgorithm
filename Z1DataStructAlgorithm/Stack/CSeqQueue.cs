using System;

namespace Z1DataStructAlgorithm.Stack
{
    public class CSeqQueue<T> : IQueue<T>
    {
        public int MaxSize { get; set; }

        private T[] _data;
        private int _front;
        private int _rear;

        public CSeqQueue(int size)
        {
            _data = new T[size];
            MaxSize = size;
            _front = _rear = -1;
        }

        public int GetLength()
        {
            return (_rear - _front + MaxSize)%MaxSize;
        }

        public bool IsEmpty()
        {
            return _front == _rear;
        }

        public bool IsFull()
        {
            return (_rear + 1)%MaxSize == _front;
        }

        public IQueue<T> Clear()
        {
            _front = _rear = -1;
            return this;
        }

        public IQueue<T> In(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Fulled");
            _data[++_rear] = item;
            return this;
        }

        public T Out()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return _data[++_front];
        }

        public T PeekFront()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return _data[_front + 1];
        }
    }
}