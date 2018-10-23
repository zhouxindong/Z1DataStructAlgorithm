using System;
using Z1DataStructAlgorithm.Helper;

namespace Z1DataStructAlgorithm.Stack
{
    public class LinkedStack <T> : IStack<T>
    {
        public int MaxSize
        {
            get { return int.MaxValue; }
            set { } 
        }

        public int Top => -1;

        public Node<T> Head { get; set; }
        public int Num { get; set; }

        public LinkedStack()
        {
            Head = null;
            Num = 0;
        }

        public int GetLength()
        {
            return Num;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public bool IsFull()
        {
            return false;
        }

        public IStack<T> Clear()
        {
            Head = null;
            Num = 0;
            return this;
        }

        public IStack<T> Push(T item)
        {
            var q = new Node<T>(item);
            if (Head == null)
                Head = q;
            else
            {
                q.Next = Head;
                Head = q;
            }

            ++Num;
            return this;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            var p = Head;
            Head = Head.Next;
            --Num;
            return p.Data;
        }

        public T PeekPop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return Head.Data;
        }
    }
}