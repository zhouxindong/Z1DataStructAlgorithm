using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Graph2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.Graph2.Tests
{
    [TestClass()]
    public class DirectedGraphTests
    {
        [TestMethod()]
        public void DikastraMinDistanceTest()
        {
            var graph = new DirectedGraph<string>();
            graph.Add(new DirectedEdge<string>("B", "A", 2));
            graph.Add(new DirectedEdge<string>("A", "C", 5));
            graph.Add(new DirectedEdge<string>("C", "B", 15));
            graph.Add(new DirectedEdge<string>("A", "D", 30));
            graph.Add(new DirectedEdge<string>("B", "E", 8));
            graph.Add(new DirectedEdge<string>("E", "D", 4));
            graph.Add(new DirectedEdge<string>("C", "F", 7));
            graph.Add(new DirectedEdge<string>("F", "E", 18));
            graph.Add(new DirectedEdge<string>("F", "D", 10));
            var dikastra = graph.DikastraMinDistance("A");

            Assert.AreEqual(20, dikastra["B"].Distance);
            Assert.AreEqual(1, dikastra["B"].RouteVertexs.Count);
            Assert.AreEqual("C", dikastra["B"].RouteVertexs[0]);

            Assert.AreEqual(5, dikastra["C"].Distance);
            Assert.AreEqual(0, dikastra["C"].RouteVertexs.Count);

            Assert.AreEqual(22, dikastra["D"].Distance);
            Assert.AreEqual(2, dikastra["D"].RouteVertexs.Count);
            Assert.AreEqual("C", dikastra["D"].RouteVertexs[0]);
            Assert.AreEqual("F", dikastra["D"].RouteVertexs[1]);

            Assert.AreEqual(28, dikastra["E"].Distance);
            Assert.AreEqual(2, dikastra["E"].RouteVertexs.Count);
            Assert.AreEqual("C", dikastra["E"].RouteVertexs[0]);
            Assert.AreEqual("B", dikastra["E"].RouteVertexs[1]);

            Assert.AreEqual(12, dikastra["F"].Distance);
            Assert.AreEqual(1, dikastra["F"].RouteVertexs.Count);
            Assert.AreEqual("C", dikastra["F"].RouteVertexs[0]);
        }

        [TestMethod()]
        public void TopologicalSortTest()
        {
            var graph = new DirectedGraph<string>();
            graph.Add(new DirectedEdge<string>("c1", "c2"));
            graph.Add(new DirectedEdge<string>("c2", "c6"));
            graph.Add(new DirectedEdge<string>("c1", "c3"));
            graph.Add(new DirectedEdge<string>("c3", "c6"));
            graph.Add(new DirectedEdge<string>("c4", "c3"));
            graph.Add(new DirectedEdge<string>("c4", "c5"));
            graph.Add(new DirectedEdge<string>("c5", "c6"));

            List<string> topological;
            var has_loop = graph.TopologicalSort(out topological);
            Assert.IsFalse(has_loop);
        }
    }
}