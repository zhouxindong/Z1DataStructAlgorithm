using System.Collections.Generic;
using Z1DataStructAlgorithm.Stack;

namespace Z1DataStructAlgorithm.Tree
{
    public class BiTree <T>
    {
        public BiTreeNode<T> Head { get; set; }

        public BiTree()
        {
            Head = null;
        }

        public BiTree(T val)
        {
            Head = new BiTreeNode<T>(val);
        }

        public BiTree(T val, BiTreeNode<T> left_child, BiTreeNode<T> right_child)
        {
            Head = new BiTreeNode<T>(val, left_child, right_child);
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public BiTreeNode<T> Root()
        {
            return Head;
        }

        public BiTreeNode<T> GetLeftChild(BiTreeNode<T> parent)
        {
            return parent.LeftChild;
        }

        public BiTreeNode<T> GetRightChild(BiTreeNode<T> parent)
        {
            return parent.RightChild;
        }

        public BiTreeNode<T> InsertLeft(T val, BiTreeNode<T> parent)
        {
            var tmp = new BiTreeNode<T>(val) {LeftChild = parent.LeftChild};
            parent.LeftChild = tmp;
            return tmp;
        }

        public BiTreeNode<T> InsertRight(T val, BiTreeNode<T> parent)
        {
            var tmp = new BiTreeNode<T>(val) {RightChild = parent.RightChild};
            parent.RightChild = tmp;
            return tmp;
        }

        public BiTreeNode<T> DeleteLeft(BiTreeNode<T> p)
        {
            if (p?.LeftChild == null) // p == null || p.LeftChild == null
                return null;
            var tmp = p.LeftChild;
            p.LeftChild = null;
            return tmp;
        }

        public BiTreeNode<T> DeleteRight(BiTreeNode<T> p)
        {
            if (p?.RightChild == null)
                return null;
            var tmp = p.RightChild;
            p.RightChild = null;
            return tmp;
        }

        public bool IsLeaf(BiTreeNode<T> p)
        {
            return (p != null) && (p.LeftChild == null) && (p.RightChild == null);
        }

        // DLR: first root, then left subtree, finally right subtree
        public IEnumerable<BiTreeNode<T>> PreOrder(BiTreeNode<T> root)
        {
            if (root == null)
                yield break;

            yield return root;
            foreach (var node in PreOrder(root.LeftChild))
            {
                yield return node;
            }
            foreach (var node in PreOrder(root.RightChild))
            {
                yield return node;
            }
        }

        // LDR: first left subtree, then root, finally right subtree
        public IEnumerable<BiTreeNode<T>> InOrder(BiTreeNode<T> root)
        {
            if (root == null)
                yield break;
            foreach (var node in InOrder(root.LeftChild))
            {
                yield return node;
            }
            yield return root;
            foreach (var node in InOrder(root.RightChild))
            {
                yield return node;
            }
        }

        // LRD: first left subtree, then right subtree, finally root
        public IEnumerable<BiTreeNode<T>> PostOrder(BiTreeNode<T> root)
        {
            if (root == null)
                yield break;
            foreach (var node in PostOrder(root.LeftChild))
            {
                yield return node;
            }
            foreach (var node in PostOrder(root.RightChild))
            {
                yield return node;
            }
            yield return root;
        }

        // Level Order: like LILO
        public IEnumerable<BiTreeNode<T>> LevelOrder(BiTreeNode<T> root)
        {
            if (root == null)
                yield break;

            var queue = new LinkedQueue<BiTreeNode<T>>();
            queue.In(root);
            while (!queue.IsEmpty())
            {
                var node = queue.Out();
                yield return node;
                if (node.LeftChild != null)
                {
                    queue.In(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    queue.In(node.RightChild);
                }
            }
        }
    }
}