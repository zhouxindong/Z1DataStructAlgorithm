namespace Z1DataStructAlgorithm.Stack
{
    public interface IStack<T>
    {
        int MaxSize { get; set; }
        int Top { get; }
        int GetLength();
        bool IsEmpty();
        bool IsFull();
        IStack<T> Clear();
        IStack<T> Push(T item);
        T Pop();
        T PeekPop();
    }
}