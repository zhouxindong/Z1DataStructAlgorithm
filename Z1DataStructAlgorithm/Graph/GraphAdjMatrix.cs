using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Z1DataStructAlgorithm.Graph
{
    public class GraphAdjMatrix<T> : IGraph<T>
    {
        private GraphNode<T>[] _nodes;
        private int[,] _matrix;
        private int[] _degrees;

        public int NumEdges { get; set; }

        public GraphAdjMatrix(int n)
        {
            _nodes = new GraphNode<T>[n];
            _degrees = new int[n];
            _matrix = new int[n, n];
            NumEdges = 0;
        }

        public GraphNode<T> this[int index]
        {
            get { return _nodes[index]; }
            set { _nodes[index] = value; }
        }

        public int this[int index1, int index2]
        {
            get { return _matrix[index1, index2]; }
            set { _matrix[index1, index2] = 1; }
        }

        public int GetMatrix(int index1, int index2)
        {
            return _matrix[index1, index2];
        }

        public int GetNumOfVertex()
        {
            return _nodes.Length;
        }

        public int GetNumOfEdge()
        {
            return NumEdges;
        }

        public int GetDegree(GraphNode<T> node)
        {
            if (!IsNode(node))
                return -1;
            return _degrees[GetIndex(node)];
        }

        public bool IsNode(GraphNode<T> v)
        {
            return _nodes.Contains(v);
        }

        public int GetIndex(GraphNode<T> v)
        {
            for (var i = 0; i < _nodes.Length; ++i)
            {
                if (_nodes[i].Equals(v))
                    return i;
            }

            return -1;
        }

        public void SetEdge(GraphNode<T> v1, GraphNode<T> v2, int v)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 not belongs to Graph");
            if (v != 1)
                throw new InvalidOperationException("Not undirection graph");
            this[GetIndex(v1), GetIndex(v2)] = v;
            this[GetIndex(v2), GetIndex(v1)] = v;
            _degrees[GetIndex(v1)]++;
            _degrees[GetIndex(v2)]++;
            ++NumEdges;
        }

        public void DelEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 not belongs to Graph");
            if (this[GetIndex(v1), GetIndex(v2)] != 1)
                return;
            this[GetIndex(v1), GetIndex(v2)] = 0;
            this[GetIndex(v2), GetIndex(v1)] = 0;
            _degrees[GetIndex(v1)]--;
            _degrees[GetIndex(v2)]--;
            --NumEdges;
        }

        public bool HasEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 not belongs to Graph");
            return this[GetIndex(v1), GetIndex(v2)] == 1;
        }

        public static GraphAdjMatrix<T> Build(IEnumerable<GraphNode<T>> nodes,
            IEnumerable<Tuple<GraphNode<T>, GraphNode<T>>> edges)
        {
            var graph = new GraphAdjMatrix<T>(nodes.Count());
            int index = 0;
            foreach (var node in nodes)
            {
                graph[index++] = node;
            }
            foreach (var edge in edges)
            {
                graph.SetEdge(edge.Item1, edge.Item2, 1);
            }
            return graph;
        }
    }
}