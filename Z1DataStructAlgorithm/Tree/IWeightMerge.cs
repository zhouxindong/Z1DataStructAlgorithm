using System;

namespace Z1DataStructAlgorithm.Tree
{
    public interface IWeightMerge<T>
    {
        T MergeWeight(T item);
    }

    public class IntWeight : IComparable<IntWeight>, IWeightMerge<IntWeight>, IComparable
    {
        public int Data { get; set; }

        public IntWeight(int data)
        {
            Data = data;
        }

        public IntWeight MergeWeight(IntWeight item)
        {
            return new IntWeight(Data + item.Data);
        }

        public int CompareTo(IntWeight other)
        {
            return Data.CompareTo(other.Data);
        }

        public int CompareTo(object obj)
        {
            return Data.CompareTo(((IntWeight)obj).Data);
        }
    }
}