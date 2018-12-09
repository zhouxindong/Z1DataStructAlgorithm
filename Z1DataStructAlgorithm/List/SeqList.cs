using System;
using Z1DataStructAlgorithm.Helper;

namespace Z1DataStructAlgorithm.List
{
    /// <summary>
    /// implement ILinearList used by array[]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqList<T> : ILinearList<T>
    {
        private readonly T[] _data;

        public T[] Data
        {
            get { return _data; }
        }

        public int Last { get; private set; }
        public int MaxSize { get; set; }

        public SeqList(int size)
        {
            _data = new T[size];
            MaxSize = size;
            Last = -1;
        }

        public T this[int index]
        {
            get { return GetElem(index); }
            set { SetElem(index, value); }
        }

        public int GetLength()
        {
            return Last + 1;
        }

        public ILinearList<T> Clear()
        {
            Last = -1;
            return this;
        }

        public bool IsEmpty()
        {
            return Last == -1;
        }

        public bool IsFull()
        {
            return Last == MaxSize - 1;
        }

        public ILinearList<T> Append(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Fulled");
            }
            _data[++Last] = item;
            return this;
        }

        public ILinearList<T> Insert(T item, int index)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Fulled");
            }

            if (IsEmpty())
            {
                return Append(item);
            }

            if (!index.InRange(0, Last + 1))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (index == Last + 1)
            {
                _data[++Last] = item;
                return this;
            }

            for (var i = Last; i >= index; --i)
            {
                _data[i + 1] = _data[i];
            }
            _data[index] = item;
            ++Last;

            return this;
        }

        public T Delete(int index)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Empty");
            }

            if (!index.InRange(0, Last))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (index == Last)
            {
                return _data[Last--];
            }

            var tmp = _data[index];
            for (var i = index; i < Last; i++)
            {
                _data[i] = _data[i + 1];
            }
            Last--;
            return tmp;
        }

        public T GetElem(int index)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");

            if (!index.InRange(0, Last))
                throw new IndexOutOfRangeException(nameof(index));

            return _data[index];
        }

        public void SetElem(int index, T value)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");

            if (!index.InRange(0, Last))
                throw new IndexOutOfRangeException(nameof(index));

            _data[index] = value;
        }

        public int Locate(T value)
        {
            if (IsEmpty())
                return -1;

            for (var i = 0; i <= Last; i++)
            {
                if (value.Equals(_data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public ILinearList<T> Reverse()
        {
            if (IsEmpty())
                return this;

            var len = GetLength();
            for (var i = 0; i < len / 2; ++i)
            {
                var tmp = _data[i];
                _data[i] = _data[len - i - 1];
                _data[len - i - 1] = tmp;
            }
            return this;
        }
    }
}