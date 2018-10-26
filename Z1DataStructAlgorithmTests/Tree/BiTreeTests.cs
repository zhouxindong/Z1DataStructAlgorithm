using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.Tree.Tests
{
    [TestClass()]
    public class BiTreeTests
    {
        /// <summary>
        ///               1
        ///            2        5
        ///         3     4          6    
        ///                      7       9
        ///                   8             10
        /// </summary>
        [TestMethod()]
        public void PreOrderTest()
        {
            var tree = new BiTree<int>(1);
            var new_node = tree.InsertLeft(2, tree.Head);
            tree.InsertLeft(3, new_node);
            tree.InsertRight(4, new_node);
            new_node = tree.InsertRight(5, tree.Head);
            var node6 = tree.InsertRight(6, new_node);
            new_node = tree.InsertLeft(7, node6);
            tree.InsertLeft(8, new_node);
            new_node = tree.InsertRight(9, node6);
            tree.InsertRight(10, new_node);

            foreach (var node in tree.PreOrder(tree.Head))
            {
                Console.WriteLine(node.Data);
            }
        }

        [TestMethod()]
        public void InOrderTest()
        {
            var tree = new BiTree<int>(1);
            var new_node = tree.InsertLeft(2, tree.Head);
            tree.InsertLeft(3, new_node);
            tree.InsertRight(4, new_node);
            new_node = tree.InsertRight(5, tree.Head);
            var node6 = tree.InsertRight(6, new_node);
            new_node = tree.InsertLeft(7, node6);
            tree.InsertLeft(8, new_node);
            new_node = tree.InsertRight(9, node6);
            tree.InsertRight(10, new_node);

            foreach (var node in tree.InOrder(tree.Head))
            {
                Console.WriteLine(node.Data);
            }
        }

        [TestMethod()]
        public void PostOrderTest()
        {
            var tree = new BiTree<int>(1);
            var new_node = tree.InsertLeft(2, tree.Head);
            tree.InsertLeft(3, new_node);
            tree.InsertRight(4, new_node);
            new_node = tree.InsertRight(5, tree.Head);
            var node6 = tree.InsertRight(6, new_node);
            new_node = tree.InsertLeft(7, node6);
            tree.InsertLeft(8, new_node);
            new_node = tree.InsertRight(9, node6);
            tree.InsertRight(10, new_node);

            foreach (var node in tree.PostOrder(tree.Head))
            {
                Console.WriteLine(node.Data);
            }
        }

        [TestMethod()]
        public void LevelOrderTest()
        {
            var tree = new BiTree<int>(1);
            var new_node = tree.InsertLeft(2, tree.Head);
            tree.InsertLeft(3, new_node);
            tree.InsertRight(4, new_node);
            new_node = tree.InsertRight(5, tree.Head);
            var node6 = tree.InsertRight(6, new_node);
            new_node = tree.InsertLeft(7, node6);
            tree.InsertLeft(8, new_node);
            new_node = tree.InsertRight(9, node6);
            tree.InsertRight(10, new_node);

            foreach (var node in tree.LevelOrder(tree.Head))
            {
                Console.WriteLine(node.Data);
            }
        }
    }
}