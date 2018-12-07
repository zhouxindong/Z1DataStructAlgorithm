using System;
using System.Collections.Generic;
using System.Linq;

namespace Z1DataStructAlgorithm.Graph2
{
    public class UndirectedGraph<T>
    {
        #region fields & constructors

        private readonly HashSet<T> _vertexs;
        private readonly HashSet<UndirectedEdge<T>> _edges;
        private readonly HashSet<T> _ergodiced_vertexs = new HashSet<T>();


        public UndirectedGraph()
        {
            _vertexs = new HashSet<T>();
            _edges = new HashSet<UndirectedEdge<T>>();
        }

        public UndirectedGraph(HashSet<UndirectedEdge<T>> edges)
        {
            _vertexs = new HashSet<T>();
            _edges = new HashSet<UndirectedEdge<T>>(edges);
            foreach (var edge in edges)
            {
                foreach (var v in edge.Vertexs())
                {
                    _vertexs.Add(v);
                }
            }
        }

        #endregion

        #region Add Vertex & Edge

        public UndirectedGraph<T> Add(T vertex)
        {
            _vertexs.Add(vertex);
            return this;
        }

        public UndirectedGraph<T> Add(UndirectedEdge<T> edge)
        {
            _edges.Add(edge);
            return this;
        }

        #endregion

        #region interfaces

        /// <summary>
        /// 获取某个顶点的所有相邻顶点
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<T> AdjoinVertexs(T vertex)
        {
            return from edge in _edges where edge.Contain(vertex) select edge.GetAdjoinVertex(vertex);
        }

        /// <summary>
        /// 图是否存在环
        /// 1.求出图中所有顶点的度，
        /// 2.删除图中所有度小于等于1的顶点以及与该顶点相关的边，把与这些边相关的顶点的度减一
        /// 3.如果还有度小于等于1的顶点重复步骤2
        /// 4.最后如果还存在未被删除的顶点，则表示有环；否则没有环
        /// </summary>
        /// <returns></returns>
        public bool HasLoop()
        {
            var dic = _vertexs.ToDictionary(v => v, v => 0); // vertex-degree
            var edges = new HashSet<UndirectedEdge<T>>(_edges);
            foreach (var edge in edges) // init degree of vertexs
            {
                foreach (var v in edge.Vertexs())
                {
                    dic[v]++;
                }
            }

            // delete all vertexs satified degree==0
            var filtered_dic = dic.Where(item => item.Value > 0).ToDictionary(item => item.Key, item => item.Value);

            var to_do_item = GetOneDegreeItem(filtered_dic); // get one vertex which degree == 1
            while (!to_do_item.Equals(default(KeyValuePair<T, int>)))
            {
                UndirectedEdge<T> to_del_edge = null;
                foreach (var edge in edges)
                {
                    if (edge.Contain(to_do_item.Key))
                    {
                        to_del_edge = edge;
                        filtered_dic[edge.GetAdjoinVertex(to_do_item.Key)]--;
                        break;
                    }
                }
                filtered_dic.Remove(to_do_item.Key);
                edges.Remove(to_del_edge);
                to_do_item = GetOneDegreeItem(filtered_dic);
            }

            return !(filtered_dic.Count == 0 ||
                     filtered_dic.All(item => item.Value == 0));
        }

        private static KeyValuePair<T, int> GetOneDegreeItem(Dictionary<T, int> dic)
        {
            return dic.FirstOrDefault(item => item.Value == 1);
        }

        #endregion

        #region Ergodic

        private IEnumerable<T> RecurErgodic(Func<T, IEnumerable<T>> iterator)
        {
            _ergodiced_vertexs.Clear();

            foreach (var vertex in _vertexs)
            {
                if (!_ergodiced_vertexs.Contains(vertex))
                {
                    foreach (var vertex2 in iterator(vertex))
                    {
                        yield return vertex2;
                    }
                }
            }
        }

        /// <summary>
        /// 假设初始状态是图中所有顶点未曾被访问过，则深度优先遍历可从图中某个顶点v出发，
        /// 访问此顶点，然后依次从v的未被访问的邻接顶点出发深度优先遍历图，直至图中所有和v有路径相通的顶点都被遍历过。
        /// 若此时图中尚有未被访问的顶点，则另选图中一个未被访问的顶点作为起始点，
        /// 重复上述过程，直到图中所有顶点都被访问到为止。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> DeepFirst()
        {
            return RecurErgodic(DeepFirst);
        }

        public IEnumerable<T> DeepFirst(T vertex)
        {
            _ergodiced_vertexs.Add(vertex);
            yield return vertex;

            foreach (var vt in AdjoinVertexs(vertex))
            {
                if (!_ergodiced_vertexs.Contains(vt))
                {
                    foreach (var vt2 in DeepFirst(vt))
                    {
                        yield return vt2;
                    }
                }
            }
        }

        /// <summary>
        /// 假设从图中的某个顶点v出发，访问了v之后，依次访问v的各个未曾访问的邻接顶点。
        /// 然后分别从这些邻接顶点出发依次访问它们的邻接顶点，
        /// 并使“先被访问的顶点的邻接顶点”先于“后被访问的顶点的邻接顶点”被访问，
        /// 直至图中所有已被访问的顶点的邻接顶点都被访问。若此时图中尚有顶点未被访问，
        /// 则另选图中未被访问的顶点作为起点，重复上述过程，直到图中所有的顶点都被访问为止。
        /// 换句话说，广度优先遍历图的过程是以某个顶点v作为起始点，由近至远，
        /// 依次访问和v有路径相通且路径长度为1，2，…的顶点。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> BreadthFirst()
        {
            return RecurErgodic(BreadthFirst);
        }

        public IEnumerable<T> BreadthFirst(T vertex)
        {
            _ergodiced_vertexs.Add(vertex);
            yield return vertex;
            var queue = new Queue<T>();
            queue.Enqueue(vertex);
            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                foreach (var item in AdjoinVertexs(v))
                {
                    if (!_ergodiced_vertexs.Contains(item))
                    {
                        _ergodiced_vertexs.Add(item);
                        yield return item;
                        queue.Enqueue(item);
                    }
                }
            }
        }

        #endregion

        #region MinCostSpanTree

        /// <summary>
        /// 假设G=（V，E）为一无向连通网，其中，V为网中顶点的集合，E为网中边的集合。
        /// 设置两个新的集合U和T，其中，U为G的最小生成树的顶点的集合，T为G的最小生成树的边的集合。
        /// 普里姆算法的思想是：令集合U的初值为U={u1}（假设构造最小生成树时从顶点u1开始），集合T的初值为T={}。
        /// 从所有的顶点u∈U和顶点v∈V-U的带权边中选出具有最小权值的边（u,v），
        /// 将顶点v加入集合U中，将边（u,v）加入集合T中。如此不断地重复直到U=V时，最小生成树构造完毕。
        /// 此时，集合U中存放着最小生成树的所有顶点，集合T中存放着最小生成树的所有边。
        /// </summary>
        /// <returns></returns>
        public List<UndirectedEdge<T>> PrimMinCostSpanTree(T begin_vertex)
        {
            if (!_vertexs.Contains(begin_vertex))
                throw new InvalidOperationException("begin_vertex is not in Graph");

            var ret = new List<UndirectedEdge<T>>();

            var selected_set = new HashSet<T>();
            var unselected_set = new HashSet<T>();
            selected_set.Add(begin_vertex);
            foreach (var vertex in _vertexs)
            {
                if (!vertex.Equals(begin_vertex))
                    unselected_set.Add(vertex);
            }

            while (unselected_set.Count > 0)
            {
                T vertex_unsel = default(T);
                UndirectedEdge<T> edge_sel = null;
                var min_cost = int.MaxValue;
                foreach (var sel_item in selected_set)
                {
                    foreach (var unsel_item in unselected_set)
                    {
                        foreach (var edge in _edges)
                        {
                            if (edge.ComposedWith(sel_item, unsel_item) && edge.Weight < min_cost)
                            {
                                vertex_unsel = unsel_item;
                                min_cost = edge.Weight;
                                edge_sel = edge;
                            }
                        }
                    }
                }

                if (vertex_unsel != null && vertex_unsel.Equals(default(T))) continue;
                selected_set.Add(vertex_unsel);
                unselected_set.Remove(vertex_unsel);
                ret.Add(edge_sel);
            }

            return ret;
        }

        /// <summary>
        /// 克鲁斯卡尔算法的基本思想是：对一个有n个顶点的无向连通网，将图中的边按权值大小依次选取，
        /// 若选取的边使生成树不形成回路，则把它加入到树中；若形成回路，则将它舍弃。
        /// 如此进行下去，直到树中包含有n-1条边为止。
        /// </summary>
        /// <returns></returns>
        public List<UndirectedEdge<T>> KruskalMinCostSpanTree()
        {
            var vertex_num = _vertexs.Count;
            var ret = new List<UndirectedEdge<T>>();
            var uncheck_edges = _edges.ToList();
            uncheck_edges.Sort();

            while (ret.Count < vertex_num - 1/*true*/)
            {
                if (uncheck_edges.Count == 0)
                    break;

                // 构建待检测图
                var to_check = new HashSet<UndirectedEdge<T>>(ret) {uncheck_edges[0]};
                var check_graph = new UndirectedGraph<T>(to_check);
                if (!check_graph.HasLoop())
                {
                    ret.Add(uncheck_edges[0]);
                }
                uncheck_edges.RemoveAt(0);
            }
            return ret;
        }

        #endregion
    }
}