using System;

namespace Z1DataStructAlgorithm.Tree
{
    public class HuffmanTreeNode<T> : BiTreeNode<T>
        where T : IComparable<T>
    {
        public HuffmanTreeNode(
            T weight,
            BiTreeNode<T> left_child,
            BiTreeNode<T> right_child,
            BiTreeNode<T> parent) : base(weight, left_child, right_child)
        {
            Parent = parent;
        }

        public HuffmanTreeNode() : this(default(T), null, null, null)
        {
        }

        public HuffmanTreeNode(T weight) : this(weight, null, null, null)
        {
        }
    }
}