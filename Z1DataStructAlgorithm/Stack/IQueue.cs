namespace Z1DataStructAlgorithm.Stack
{
    public interface IQueue<T>
    {
        int GetLength();
        bool IsEmpty();
        IQueue<T> Clear();
        IQueue<T> In(T item);
        T Out();
        T PeekFront();
    }
}