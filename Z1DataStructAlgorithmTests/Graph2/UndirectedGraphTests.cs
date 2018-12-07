using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Graph2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.Graph2.Tests
{
    [TestClass()]
    public class UndirectedGraphTests
    {
        [TestMethod()]
        public void DeepFirstTest()
        {
            var graph = new UndirectedGraph<string>();
            graph.Add("v1");
            graph.Add("v2");
            graph.Add("v3");
            graph.Add("v4");
            graph.Add("v5");
            graph.Add("v6");
            graph.Add("v7");
            graph.Add("v8");
            graph.Add(new UndirectedEdge<string>("v1", "v2"));
            graph.Add(new UndirectedEdge<string>("v1", "v3"));
            graph.Add(new UndirectedEdge<string>("v2", "v4"));
            graph.Add(new UndirectedEdge<string>("v2", "v5"));
            graph.Add(new UndirectedEdge<string>("v4", "v8"));
            graph.Add(new UndirectedEdge<string>("v5", "v8"));
            graph.Add(new UndirectedEdge<string>("v3", "v6"));
            graph.Add(new UndirectedEdge<string>("v3", "v7"));
            graph.Add(new UndirectedEdge<string>("v6", "v7"));

            foreach (var vertex in graph.DeepFirst())
            {
                Console.WriteLine(vertex);
            }
        }

        [TestMethod()]
        public void BreadthFirstTest()
        {
            var graph = new UndirectedGraph<string>();
            graph.Add("v1");
            graph.Add("v2");
            graph.Add("v3");
            graph.Add("v4");
            graph.Add("v5");
            graph.Add("v6");
            graph.Add("v7");
            graph.Add("v8");
            graph.Add(new UndirectedEdge<string>("v1", "v2"));
            graph.Add(new UndirectedEdge<string>("v1", "v3"));
            graph.Add(new UndirectedEdge<string>("v2", "v4"));
            graph.Add(new UndirectedEdge<string>("v2", "v5"));
            graph.Add(new UndirectedEdge<string>("v4", "v8"));
            graph.Add(new UndirectedEdge<string>("v5", "v8"));
            graph.Add(new UndirectedEdge<string>("v3", "v6"));
            graph.Add(new UndirectedEdge<string>("v3", "v7"));
            graph.Add(new UndirectedEdge<string>("v6", "v7"));

            foreach (var vertex in graph.BreadthFirst())
            {
                Console.WriteLine(vertex);
            }
        }

        [TestMethod()]
        public void PrimMinCostSpanTreeTest()
        {
            var graph = new UndirectedGraph<string>();
            graph.Add("A");
            graph.Add("B");
            graph.Add("C");
            graph.Add("D");
            graph.Add("E");
            graph.Add(new UndirectedEdge<string>("B", "A", 60));
            graph.Add(new UndirectedEdge<string>("B", "D", 95));
            graph.Add(new UndirectedEdge<string>("B", "C", 80));
            graph.Add(new UndirectedEdge<string>("A", "C", 100));
            graph.Add(new UndirectedEdge<string>("A", "D", 20));
            graph.Add(new UndirectedEdge<string>("C", "E", 70));
            graph.Add(new UndirectedEdge<string>("D", "E", 10));

            var prim = graph.PrimMinCostSpanTree("A");
            Assert.AreEqual(4, prim.Count);
        }

        [TestMethod()]
        public void HasLoopTest()
        {
            var ae = new UndirectedEdge<string>("A", "E");
            var ab = new UndirectedEdge<string>("A", "B");
            var bc = new UndirectedEdge<string>("B", "C");
            var cd = new UndirectedEdge<string>("C", "D");
            var de = new UndirectedEdge<string>("D", "E");
            var bd = new UndirectedEdge<string>("B", "D");
            var be = new UndirectedEdge<string>("B", "E");

            var edges = new HashSet<UndirectedEdge<string>> { ab, bc, cd, de, ae };
            var graph = new UndirectedGraph<string>(edges);
            Assert.IsTrue(graph.HasLoop());

            edges = new HashSet<UndirectedEdge<string>> { ae, ab, bc, cd, bd };
            graph = new UndirectedGraph<string>(edges);
            graph.Add("O");
            Assert.IsTrue(graph.HasLoop());

            edges = new HashSet<UndirectedEdge<string>>() { ab, bc, cd, de };
            graph = new UndirectedGraph<string>(edges);
            Assert.IsFalse(graph.HasLoop());

            edges = new HashSet<UndirectedEdge<string>>() { ae, be, bc, cd, de };
            graph = new UndirectedGraph<string>(edges);
            Assert.IsTrue(graph.HasLoop());
        }

        [TestMethod()]
        public void KruskalMinCostSpanTreeTest()
        {
            var graph = new UndirectedGraph<string>();
            graph.Add("A");
            graph.Add("B");
            graph.Add("C");
            graph.Add("D");
            graph.Add("E");
            graph.Add(new UndirectedEdge<string>("B", "A", 60));
            graph.Add(new UndirectedEdge<string>("B", "D", 95));
            graph.Add(new UndirectedEdge<string>("B", "C", 80));
            graph.Add(new UndirectedEdge<string>("A", "C", 100));
            graph.Add(new UndirectedEdge<string>("A", "D", 20));
            graph.Add(new UndirectedEdge<string>("C", "E", 70));
            graph.Add(new UndirectedEdge<string>("D", "E", 10));

            var kruskal = graph.KruskalMinCostSpanTree();
            Assert.AreEqual(4, kruskal.Count);
        }
    }
}