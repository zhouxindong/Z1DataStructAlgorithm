namespace Z1DataStructAlgorithm.List
{
    /// <summary>
    /// interface for linear list
    /// </summary>
    public interface ILinearList<T>
    {
        int GetLength();
        ILinearList<T> Clear();
        bool IsEmpty();
        ILinearList<T> Append(T item);
        ILinearList<T> Insert(T item, int i);
        T Delete(int i);
        T GetElem(int i);
        int Locate(T value);
    }
}