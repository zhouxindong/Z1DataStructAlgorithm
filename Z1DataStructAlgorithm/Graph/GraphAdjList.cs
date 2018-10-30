using System;
using System.Collections.Generic;
using System.Linq;
using Z1DataStructAlgorithm.Stack;

namespace Z1DataStructAlgorithm.Graph
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GraphAdjList<T> : IGraph<T>
    {
        public VexNode<T>[] AdjList { get; set; }

        private readonly int[] _visited;

        public VexNode<T> this[int index]
        {
            get { return AdjList[index]; }
            set { AdjList[index] = value; }
        }

        public GraphAdjList(GraphNode<T>[] nodes)
        {
            AdjList = new VexNode<T>[nodes.Length];
            for (var i = 0; i < nodes.Length; i++)
            {
                //AdjList[i].Data = nodes[i];
                //AdjList[i].FirstAdj = null;
                AdjList[i] = new VexNode<T>(nodes[i]);
            }

            _visited = new int[AdjList.Length];
            for (var i = 0; i < _visited.Length; i++)
            {
                _visited[i] = 0;
            }
        }

        public int GetNumOfVertex()
        {
            return AdjList.Length;
        }

        public int GetNumOfEdge()
        {
            int i = 0;
            foreach (var node in AdjList)
            {
                var p = node.FirstAdj;
                while (p != null)
                {
                    ++i;
                    p = p.Next;
                }
            }
            return i/2;
        }

        public bool IsNode(GraphNode<T> v)
        {
            return AdjList.Any(node => v.Equals(node.Data));
        }

        public int GetIndex(GraphNode<T> v)
        {
            for (var i = 0; i < AdjList.Length; i++)
            {
                if (AdjList[i].Data.Equals(v))
                    return i;
            }

            return -1;
        }

        public void SetEdge(GraphNode<T> v1, GraphNode<T> v2, int v)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 not belong to Graph");
            if (HasEdge(v1, v2))
                return;

            if (v != 1)
                throw new InvalidOperationException("Not a Undirection Grapth");
            var p = new AdjListNode<T>(GetIndex(v2));
            if ((AdjList[GetIndex(v1)]).FirstAdj == null)
            {
                AdjList[GetIndex(v1)].FirstAdj = p;
            }
            else
            {
                p.Next = AdjList[GetIndex(v1)].FirstAdj;
                AdjList[GetIndex(v1)].FirstAdj = p;
            }

            p = new AdjListNode<T>(GetIndex(v1));
            if (AdjList[GetIndex(v2)].FirstAdj == null)
            {
                AdjList[GetIndex(v2)].FirstAdj = p;
            }
            else
            {
                p.Next = AdjList[GetIndex(v2)].FirstAdj;
                AdjList[GetIndex(v2)].FirstAdj = p;
            }
        }

        public void DelEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 not belong to Graph");
            if (!HasEdge(v1, v2))
                return;

            var p = AdjList[GetIndex(v1)].FirstAdj;
            AdjListNode<T> pre = null;
            while (p != null)
            {
                if (p.AdjVex != GetIndex(v2))
                {
                    pre = p;
                    p = p.Next;
                }
            }
            pre.Next = p.Next;

            p = AdjList[GetIndex(v2)].FirstAdj;
            pre = null;
            while (p != null)
            {
                if (p.AdjVex != GetIndex(v1))
                {
                    pre = p;
                    p = p.Next;
                }
            }

            pre.Next = p.Next;
        }

        public bool HasEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            if (!IsNode(v1) || !IsNode(v2))
                throw new InvalidOperationException("v1 or v2 not belong to Graph");

            var p = AdjList[GetIndex(v1)].FirstAdj;
            while (p != null)
            {
                if (p.AdjVex == GetIndex(v2))
                {
                    return true;
                }

                p = p.Next;
            }
            return false;
        }

        public IEnumerable<VexNode<T>> DeepFirst()
        {
            for (int i = 0; i < _visited.Length; i++)
            {
                if (_visited[i] == 0)
                {
                    foreach (var node in DeepFirst(i))
                    {
                        yield return node;
                    }
                }
            }
        }

        public IEnumerable<VexNode<T>> DeepFirst(int index)
        {
            _visited[index] = 1;
            yield return this[index];

            var p = AdjList[index].FirstAdj;
            while (p != null)
            {
                if (_visited[p.AdjVex] == 0)
                {
                    foreach (var node in DeepFirst(p.AdjVex))
                    {
                        yield return node;
                    }
                }

                p = p.Next;
            }
        }

        public IEnumerable<VexNode<T>> BreadthFirst()
        {
            for (int i = 0; i < _visited.Length; i++)
            {
                if (_visited[i] == 0)
                {
                    foreach (var node in BreadthFirst(i))
                    {
                        yield return node;
                    }
                }
            }
        }

        public IEnumerable<VexNode<T>> BreadthFirst(int index)
        {
            _visited[index] = 1;
            yield return this[index];
            var cq = new CSeqQueue<int>(_visited.Length);
            cq.In(index);
            while (!cq.IsEmpty())
            {
                int k = cq.Out();
                var p = AdjList[k].FirstAdj;
                while (p != null)
                {
                    if (_visited[p.AdjVex] == 0)
                    {
                        _visited[p.AdjVex] = 1;
                        yield return this[p.AdjVex];
                        cq.In(p.AdjVex);
                    }
                    p = p.Next;
                }
            }
        }
    }
}