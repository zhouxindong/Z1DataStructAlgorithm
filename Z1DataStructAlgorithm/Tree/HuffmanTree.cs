using System;
using System.Collections.Generic;
using System.Linq;

namespace Z1DataStructAlgorithm.Tree
{
    public class HuffmanTree<T> : BiTree<T>, IComparable<T>, IComparable
        where T : IComparable<T>, IWeightMerge<T>, IComparable
    {
        public HuffmanTree(List<T> data)
        {
            if (data == null || data.Count == 0)
                return;

            if (data.Count == 1)
            {
                Head = new HuffmanTreeNode<T>(data[0]);
                return;
            }

            BuildTree(ConvertDataToTree(data));
        }

        private HuffmanTree(T item)
        {
            Head = new HuffmanTreeNode<T>(item);
        }

        private static List<HuffmanTree<T>> ConvertDataToTree(IEnumerable<T> data)
        {
            return data.Select(item => new HuffmanTree<T>(item)).ToList();
        }

        private void BuildTree(List<HuffmanTree<T>> data)
        {
            if (data.Count <= 1)
            {
                Head = data[0].Head;
                return;
            }

            var min_pair = FindMinWeightPair(data);
            var new_tree = new HuffmanTree<T>(min_pair.Item1.Head.Data.MergeWeight(min_pair.Item2.Head.Data))
            {
                Head =
                {
                    LeftChild = min_pair.Item1.Head,
                    RightChild = min_pair.Item2.Head
                }
            };
            min_pair.Item1.Head.Parent = new_tree.Head;
            min_pair.Item2.Head.Parent = new_tree.Head;

            data.Add(new_tree);
            data.Remove(min_pair.Item1);
            data.Remove(min_pair.Item2);

            BuildTree(data);
        }

        private Tuple<HuffmanTree<T>, HuffmanTree<T>> FindMinWeightPair(List<HuffmanTree<T>> data)
        {
            data.Sort();
            return new Tuple<HuffmanTree<T>, HuffmanTree<T>>(data[0], data[1]);
        }

        public int CompareTo(T other)
        {
            return Head.Data.CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            return Head.Data.CompareTo(((HuffmanTree<T>)obj).Head.Data);
        }
    }
}