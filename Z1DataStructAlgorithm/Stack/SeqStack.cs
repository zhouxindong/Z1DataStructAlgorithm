using System;

namespace Z1DataStructAlgorithm.Stack
{
    public class SeqStack<T> : IStack<T>
    {
        public int MaxSize { get; set; }
        public int Top { get; private set; }

        private T[] _data;

        public SeqStack(int size)
        {
            _data = new T[size];
            MaxSize = size;
            Top = -1;
        }

        public int GetLength()
        {
            return Top + 1;
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }

        public bool IsFull()
        {
            return Top == MaxSize - 1;
        }

        public IStack<T> Clear()
        {
            Top = -1;
            return this;
        }

        public IStack<T> Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Fulled");
            _data[++Top] = item;
            return this;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return _data[Top--];
        }

        public T PeekPop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return _data[Top];
        }
    }
}