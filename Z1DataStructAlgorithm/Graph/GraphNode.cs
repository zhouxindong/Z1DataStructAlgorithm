namespace Z1DataStructAlgorithm.Graph
{
    public class GraphNode<T>
    {
        public T Data { get; set; }

        public GraphNode(T data)
        {
            Data = data;
        }
    }
}