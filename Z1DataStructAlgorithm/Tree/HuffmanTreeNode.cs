namespace Z1DataStructAlgorithm.Tree
{
    public class HuffmanTreeNode
    {
        public int Weight { get; set; }
        public int LeftChild { get; set; }
        public int RightChild { get; set; }
        public int Parent { get; set; }

        public HuffmanTreeNode(int weight, int left_child, int right_child, int parent)
        {
            Weight = weight;
            LeftChild = left_child;
            RightChild = right_child;
            Parent = parent;
        }

        public HuffmanTreeNode() : this(0, -1, -1, -1) { }
    }
}