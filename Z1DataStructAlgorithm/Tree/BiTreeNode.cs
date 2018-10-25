namespace Z1DataStructAlgorithm.Tree
{
    public class BiTreeNode<T>
    {
        public T Data { get; set; }
        public BiTreeNode<T> LeftChild { get; set; }
        public BiTreeNode<T> RightChild { get; set; }

        public BiTreeNode(T val, BiTreeNode<T> lp, BiTreeNode<T> rp)
        {
            Data = val;
            LeftChild = lp;
            RightChild = rp;
        }

        public BiTreeNode(BiTreeNode<T> lp, BiTreeNode<T> rp) : this(default(T), lp, rp)
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