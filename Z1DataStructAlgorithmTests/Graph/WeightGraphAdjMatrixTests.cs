using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.Graph.Tests
{
    [TestClass()]
    public class WeightGraphAdjMatrixTests
    {
        [TestMethod()]
        public void PrimMinCostSpanTreeTest()
        {
            var graph = new WeightGraphAdjMatrix<string>(5);
            var a = graph[0] = new GraphNode<string>("A");
            var b = graph[1] = new GraphNode<string>("B");
            var c = graph[2] = new GraphNode<string>("C");
            var d = graph[3] = new GraphNode<string>("D");
            var e = graph[4] = new GraphNode<string>("E");

            graph.SetEdge(a, b, 60);
            graph.SetEdge(a, d, 20);
            graph.SetEdge(a, c, 100);
            graph.SetEdge(b, d, 95);
            graph.SetEdge(b, c, 80);
            graph.SetEdge(c, e, 70);
            graph.SetEdge(d, e, 10);

            var prim = graph.PrimMinCostSpanTree();
            Assert.AreEqual(4, prim.Count);
        }
    }
}