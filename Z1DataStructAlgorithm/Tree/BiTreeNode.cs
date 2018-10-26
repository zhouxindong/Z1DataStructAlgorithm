namespace Z1DataStructAlgorithm.Tree
{
    public class BiTreeNode<T>
    {
        public T Data { get; set; }
        public BiTreeNode<T> LeftChild { get; set; }
        public BiTreeNode<T> RightChild { get; set; }

        public BiTreeNode(T val, BiTreeNode<T> left_child, BiTreeNode<T> right_child)
        {
            Data = val;
            LeftChild = left_child;
            RightChild = right_child;
        }

        public BiTreeNode(BiTreeNode<T> left_child, BiTreeNode<T> right_child) : this(default(T), left_child, right_child)
        {
        }

        public BiTreeNode(T val) : this(val, null, null)
        {
        }

        public BiTreeNode() : this(default(T), null, null)
        {
        }


    }
}