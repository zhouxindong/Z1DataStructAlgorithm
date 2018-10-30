using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.Graph.Tests
{
    [TestClass()]
    public class GraphAdjListTests
    {
        [TestMethod()]
        public void DeepFirstTest()
        {
            var nodes = new GraphNode<int>[8];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new GraphNode<int>(i + 1);
            }

            var graph = new GraphAdjList<int>(nodes);
            graph.SetEdge(nodes[0], nodes[1], 1);
            graph.SetEdge(nodes[0], nodes[2], 1);
            graph.SetEdge(nodes[1], nodes[3], 1);
            graph.SetEdge(nodes[1], nodes[4], 1);
            graph.SetEdge(nodes[3], nodes[7], 1);
            graph.SetEdge(nodes[4], nodes[7], 1);
            graph.SetEdge(nodes[2], nodes[5], 1);
            graph.SetEdge(nodes[2], nodes[6], 1);
            graph.SetEdge(nodes[5], nodes[6], 1);

            foreach (var node in graph.DeepFirst())
            {
                Console.WriteLine(node.Data.Data);
            }
        }

        [TestMethod()]
        public void BreadthFirstTest()
        {
            var nodes = new GraphNode<int>[8];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new GraphNode<int>(i + 1);
            }

            var graph = new GraphAdjList<int>(nodes);
            graph.SetEdge(nodes[0], nodes[1], 1);
            graph.SetEdge(nodes[0], nodes[2], 1);
            graph.SetEdge(nodes[1], nodes[3], 1);
            graph.SetEdge(nodes[1], nodes[4], 1);
            graph.SetEdge(nodes[3], nodes[7], 1);
            graph.SetEdge(nodes[4], nodes[7], 1);
            graph.SetEdge(nodes[2], nodes[5], 1);
            graph.SetEdge(nodes[2], nodes[6], 1);
            graph.SetEdge(nodes[5], nodes[6], 1);

            foreach (var node in graph.BreadthFirst())
            {
                Console.WriteLine(node.Data.Data);
            }
        }
    }
}