using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Z1DataStructAlgorithm.Tree.Tests
{
    [TestClass()]
    public class HuffmanTreeTests
    {
        [TestMethod()]
        public void HuffmanTreeTest()
        {
            var data_list = new List<IntWeight>
            {
                new IntWeight(4),
                new IntWeight(3),
                new IntWeight(2),
                new IntWeight(1),
                new IntWeight(5)
            };
            var huffman_tree = new HuffmanTree<IntWeight>(data_list);
            foreach (var node in huffman_tree.PreOrder(huffman_tree.Head))
            {
                Console.WriteLine(node.Data.Data);
            }
        }
    }
}