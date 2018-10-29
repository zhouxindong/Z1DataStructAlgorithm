namespace Z1DataStructAlgorithm.Graph
{
    public class AdjListNode<T>
    {
        public int AdjVex { get; set; }
        public AdjListNode<T> Next { get; set; }

        public AdjListNode(int vex)
        {
            AdjVex = vex;
            Next = null;
        }
    }
}