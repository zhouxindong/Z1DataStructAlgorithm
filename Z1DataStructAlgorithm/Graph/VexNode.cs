namespace Z1DataStructAlgorithm.Graph
{
    public class VexNode<T>
    {
        public GraphNode<T> Data { get; set; }
        public AdjListNode<T> FirstAdj { get; set; }

        public VexNode(GraphNode<T> data, AdjListNode<T> first_adj)
        {
            Data = data;
            FirstAdj = first_adj;
        } 

        public VexNode() : this(null, null) { }

        public VexNode(GraphNode<T> data) : this(data, null) { }
    }
}