namespace Z1DataStructAlgorithm.Helper
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }

        public Node(Node<T> next) : this(default(T), next)
        {
        }

        public Node(T data) : this(data, null)
        {
        }

        public Node() : this(default(T), null)
        {
        }
    }
}