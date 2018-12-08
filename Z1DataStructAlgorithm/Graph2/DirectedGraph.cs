using System;
using System.Collections.Generic;
using System.Linq;

namespace Z1DataStructAlgorithm.Graph2
{
    public class DirectedGraph<T>
    {
        #region fields & constructors

        private readonly HashSet<T> _vertexs;
        private readonly HashSet<DirectedEdge<T>> _edges;

        public DirectedGraph()
        {
            _vertexs = new HashSet<T>();
            _edges = new HashSet<DirectedEdge<T>>();
        }

        public DirectedGraph(HashSet<DirectedEdge<T>> edges)
        {
            _vertexs = new HashSet<T>();
            _edges = new HashSet<DirectedEdge<T>>(edges);
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

        public DirectedGraph<T> Add(T vertex)
        {
            _vertexs.Add(vertex);
            return this;
        }

        public DirectedGraph<T> Add(DirectedEdge<T> edge)
        {
            _edges.Add(edge);
            foreach (var vertex in edge.Vertexs())
            {
                _vertexs.Add(vertex);
            }
            return this;
        }

        #endregion

        #region public interfaces

        /// <summary>
        /// 获得以某个节点为源点的所有相邻节点及权值
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<Tuple<T, int>> AdjoinVertexs(T vertex)
        {
            return from edge in _edges
                where edge.BeginVertex.Equals(vertex)
                select new Tuple<T, int>(edge.EndVertex, edge.Weight);
        }

        /// <summary>
        /// Dikastra最短路径
        /// </summary>
        /// <param name="source_vertex"></param>
        /// <returns></returns>
        public Dictionary<T, MinDistanceRoute<T>> DikastraMinDistance(T source_vertex)
        {
            var s_set = new HashSet<T> {source_vertex}; // 已判定最小路径的节点集合
            var t_set = new HashSet<T>(_vertexs);       // 未判定最小路径的节点集合
            t_set.Remove(source_vertex);
            var routes = InitRoutes(source_vertex);
            while (t_set.Count > 0)
            {
                var sel_vertex = FindCurMinDistance(t_set, routes);
                s_set.Add(sel_vertex);
                t_set.Remove(sel_vertex);
                UpdateDistance(sel_vertex, t_set, routes);
            }

            return routes;
        }

        private Dictionary<T, MinDistanceRoute<T>> InitRoutes(T source_vertex)
        {
            var distance_route_map = new Dictionary<T, MinDistanceRoute<T>>();
            foreach (var vertex in _vertexs)
            {
                if (vertex.Equals(source_vertex))
                    continue;
                distance_route_map.Add(vertex, new MinDistanceRoute<T>()
                {
                    SourceVertex = source_vertex,
                    DestinationVertex = vertex,
                    Distance = int.MaxValue,
                });
            }

            foreach (var item in AdjoinVertexs(source_vertex))
            {
                if (distance_route_map.ContainsKey(item.Item1))
                {
                    distance_route_map[item.Item1].Distance = item.Item2;
                }
            }

            return distance_route_map;
        }

        private static T FindCurMinDistance(HashSet<T> t_set, Dictionary<T, MinDistanceRoute<T>> routes)
        {
            var find_vertex = default(T);
            var min_weight = int.MaxValue;
            foreach (var vertex in t_set)
            {
                if (!routes.ContainsKey(vertex)) continue;
                if (routes[vertex].Distance >= min_weight) continue;
                find_vertex = vertex;
                min_weight = routes[vertex].Distance;
            }
            return find_vertex;
        }

        private void UpdateDistance(T sel_vertex, HashSet<T> t_set, Dictionary<T, MinDistanceRoute<T>> routes)
        {
            var sel_distance = routes[sel_vertex].Distance;
            var adjoin_vertexs = AdjoinVertexs(sel_vertex);
            var adjoin_vertices = adjoin_vertexs as Tuple<T, int>[] ?? adjoin_vertexs.ToArray();
            foreach (var adjoin_vertex in adjoin_vertices)
            {
                if (!t_set.Contains(adjoin_vertex.Item1)) continue;
                if (!routes.ContainsKey(adjoin_vertex.Item1)) continue;
                var new_distance = sel_distance + adjoin_vertex.Item2;
                if (new_distance >= routes[adjoin_vertex.Item1].Distance) continue;
                routes[adjoin_vertex.Item1].UpdateRoute(routes[sel_vertex].RouteVertexs, sel_vertex);
                routes[adjoin_vertex.Item1].Distance = new_distance;
            }
        }

        /// <summary>
        /// 有向图的拓扑排序
        /// </summary>
        /// <returns>true时此有向图存在环，false则没有环</returns>
        public bool TopologicalSort(out List<T> sorted_list)
        {
            var vertexs = new HashSet<T>(_vertexs);
            var edges = new HashSet<DirectedEdge<T>>(_edges);
            T zero_vertex;
            sorted_list = new List<T>();

            while (FindIncomingDegreeZeroVertex(vertexs, edges, out zero_vertex))
            {
                sorted_list.Add(zero_vertex);
                vertexs.Remove(zero_vertex);
                RemoveAllArcToVertex(zero_vertex, edges);
            }

            return vertexs.Count != 0; // 没有入度为0的节点，但还存在未输出的节点，说明存在环
        }

        private bool FindIncomingDegreeZeroVertex(HashSet<T> vertexs, HashSet<DirectedEdge<T>> edges, out T result)
        {
            var candicated = new HashSet<T>(vertexs);
            foreach (var edge in edges)
            {
                if (candicated.Contains(edge.EndVertex))
                    candicated.Remove(edge.EndVertex);
            }
            result = candicated.Count > 0 ? candicated.ElementAt(0) : default(T);
            return candicated.Count > 0;
        }

        private void RemoveAllArcToVertex(T vertex, HashSet<DirectedEdge<T>> edges)
        {
            edges.RemoveWhere(edge => edge.BeginVertex.Equals(vertex));
        }

        #endregion

    }
}