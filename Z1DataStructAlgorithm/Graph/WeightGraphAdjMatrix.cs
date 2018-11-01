using System;
using System.Collections.Generic;
using System.Linq;

namespace Z1DataStructAlgorithm.Graph
{
    public class WeightGraphAdjMatrix<T> : IGraph<T>
    {
        private readonly GraphNode<T>[] _nodes;
        private readonly int[,] _matrix;
        public int NumEdges { get; set; }

        public WeightGraphAdjMatrix(int n)
        {
            _nodes = new GraphNode<T>[n];
            _matrix = new int[n, n];
            NumEdges = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _matrix[i, j] = int.MaxValue;
                }
            }
        }

        public GraphNode<T> this[int index]
        {
            get { return _nodes[index]; }
            set { _nodes[index] = value; }
        }

        public int this[int index1, int index2]
        {
            get { return _matrix[index1, index2]; }
            set { _matrix[index1, index2] = value; }
        }

        public bool IsNode(GraphNode<T> nd)
        {
            return _nodes.Contains(nd);
        }

        public int GetIndex(GraphNode<T> nd)
        {
            for (var i = 0; i < _nodes.Length; i++)
            {
                if (_nodes[i].Equals(nd))
                    return i;
            }
            return -1;
        }

        public void DelEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            if (!IsNode(v1) || !IsNode(v2))
            {
                throw new InvalidOperationException("v1 or v2 is not belongs to Graph");
            }
            if (_matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
            {
                _matrix[GetIndex(v1), GetIndex(v2)] = int.MaxValue;
                _matrix[GetIndex(v2), GetIndex(v1)] = int.MaxValue;
                --NumEdges;
            }
        }

        public int GetNumOfEdge()
        {
            return NumEdges;;
        }

        public int GetNumOfVertex()
        {
            return _nodes.Length;
        }

        public bool HasEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 is not belong to Graph");
            return _matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue;
        }

        public void SetEdge(GraphNode<T> v1, GraphNode<T> v2, int v)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 is not belongs to Graph");
            _matrix[GetIndex(v1), GetIndex(v2)] = v;
            _matrix[GetIndex(v2), GetIndex(v1)] = v;
            ++NumEdges;
        }

        public List<Tuple<int, int>>  PrimMinCostSpanTree()
        {
            var ret = new List<Tuple<int, int>>();

            var selected_set = new HashSet<int>();
            var unselected_set = new HashSet<int>();
            selected_set.Add(0);
            for (var i = 1; i < _nodes.Length; i++)
            {
                unselected_set.Add(i);
            }

            while (true)
            {
                var sel_index1 = -1;
                var sel_index2 = -1;
                var min_cost = int.MaxValue;
                foreach (var sel_item in selected_set)
                {
                    foreach (var unsel_item in unselected_set)
                    {
                        if (this[sel_item, unsel_item] < min_cost)
                        {
                            sel_index1 = sel_item;
                            sel_index2 = unsel_item;
                            min_cost = this[sel_item, unsel_item];
                        }
                    }
                }

                selected_set.Add(sel_index2);
                unselected_set.Remove(sel_index2);
                ret.Add(new Tuple<int, int>(sel_index1, sel_index2));

                if (unselected_set.Count == 0)
                    break;
            }

            return ret;
        }
    }
}