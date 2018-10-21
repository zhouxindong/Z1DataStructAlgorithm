namespace Z1DataStructAlgorithm.List
{
    /// <summary>
    /// interface for linear list
    /// </summary>
    public interface ILinearList<T>
    {
        int MaxSize { get; set; }
        int Last { get; }

        int GetLength();
        ILinearList<T> Clear();
        bool IsEmpty();
        bool IsFull();
        ILinearList<T> Append(T item);
        ILinearList<T> Insert(T item, int index);
        T Delete(int index);
        T GetElem(int index);
        int Locate(T value);
        ILinearList<T> Reverse();
    }
}