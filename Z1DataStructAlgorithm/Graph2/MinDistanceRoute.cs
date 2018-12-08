using System.Collections.Generic;

namespace Z1DataStructAlgorithm.Graph2
{
    public class MinDistanceRoute <T>
    {
        public T SourceVertex { get; set; }
        public T DestinationVertex { get; set; }
        public List<T> RouteVertexs { get; }
        public int Distance { get; set; }

        public MinDistanceRoute()
        {
            RouteVertexs = new List<T>();
        }

        public void UpdateRoute(List<T> sel_vertex_routes, T sel_vertex)
        {
            RouteVertexs.Clear();
            RouteVertexs.AddRange(sel_vertex_routes);
            RouteVertexs.Add(sel_vertex);
        }
    }
}