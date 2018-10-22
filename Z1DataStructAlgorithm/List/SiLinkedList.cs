using System;
using Z1DataStructAlgorithm.Helper;

namespace Z1DataStructAlgorithm.List
{
    public class SiLinkedList<T> : ILinearList<T>
    {
        public Node<T> Head { get; set; }

        public SiLinkedList()
        {
            Head = null;
        }

        public int MaxSize
        {
            get { return int.MaxValue; }
            set { }
        }

        public int Last => int.MaxValue;

        public int GetLength()
        {
            var p = Head;
            var len = 0;
            while (p != null)
            {
                ++len;
                p = p.Next;
            }
            return len;
        }

        public ILinearList<T> Clear()
        {
            Head = null;
            return this;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public bool IsFull()
        {
            return false;
        }

        public ILinearList<T> Append(T item)
        {
            var q = new Node<T>(item);
            if (Head == null)
            {
                Head = q;
                return this;
            }

            var p = Head;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = q;
            return this;
        }

        public ILinearList<T> Insert(T item, int index)
        {
            if (IsEmpty())
            {
                return Append(item);
            }

            if (index == 0)
            {
                var q = new Node<T>(item, Head);
                Head = q;
                return this;
            }

            var p = Head;
            var r = new Node<T>();
            var i = 0;

            while (p.Next != null && i < index)
            {
                r = p;
                p = p.Next;
                ++i;
            }

            if (i == index)
            {
                var q = new Node<T>(item, p);
                r.Next = q;
                return this;
            }
            else // at last
            {
                var q = new Node<T>(item);
                p.Next = q;
                return this;
            }
        }

        public T Delete(int index)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");

            if(index < 0)
                throw new IndexOutOfRangeException(nameof(index));

            if (index == 0)
            {
                var q = Head;
                Head = Head.Next;
                return q.Data;
            }

            var p = Head;
            var r = new Node<T>();
            var i = 0;

            while (p.Next != null && i < index)
            {
                r = p;
                p = p.Next;
                ++i;
            }

            if (i != index) throw new IndexOutOfRangeException(nameof(index));
            r.Next = p.Next;
            return p.Data;
        }

        public T GetElem(int index)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");

            if (index < 0)
                throw new IndexOutOfRangeException(nameof(index));

            if (index == 0)
                return Head.Data;

            var p = Head;
            var i = 0;

            while (p.Next != null && i < index)
            {
                p = p.Next;
                ++i;
            }

            if (i != index) throw new IndexOutOfRangeException(nameof(index));
            return p.Data;
        }

        public int Locate(T value)
        {
            if (IsEmpty())
                return -1;

            var p = Head;
            var i = 0;
            while (!p.Data.Equals(value))
            {
                p = p.Next;
                ++i;
                if (p == null)
                    return -1;
            }

            return i;
        }

        public ILinearList<T> Reverse()
        {
            if (IsEmpty() || GetLength() == 1)
                return this;

            var p = Head.Next;
            Head.Next = null;
            while (p != null)
            {
                var q = p;
                p = p.Next;
                q.Next = Head;
                Head = q;
            }
            return this;
        }
    }
}