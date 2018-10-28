namespace Z1DataStructAlgorithm.Graph
{
    public interface IGraph<T>
    {
        int GetNumOfVertex();
        int GetNumOfEdge();
        void SetEdge(GraphNode<T> v1, GraphNode<T> v2, int v);
        void DelEdge(GraphNode<T> v1, GraphNode<T> v2);
        bool HasEdge(GraphNode<T> v1, GraphNode<T> v2);
    }
}