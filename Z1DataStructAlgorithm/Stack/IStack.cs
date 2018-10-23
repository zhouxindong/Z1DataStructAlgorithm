namespace Z1DataStructAlgorithm.Stack
{
    public interface IStack<T>
    {
        int GetLength();
        bool IsEmpty();
        IStack<T> Clear();
        IStack<T> Push(T item);
        T Pop();
        T PeekPop();
    }
}