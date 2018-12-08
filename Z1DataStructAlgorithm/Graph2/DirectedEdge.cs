using System;
using System.Collections.Generic;

namespace Z1DataStructAlgorithm.Graph2
{
    public class DirectedEdge <T> : IComparable
    {
        private readonly Guid _guid;
        public T BeginVertex { get; }
        public T EndVertex { get; }

        public int Weight { get; }

        public DirectedEdge(T from, T to, int weight)
        {
            BeginVertex = from;
            EndVertex = to;
            Weight = weight;
            _guid = Guid.NewGuid();
        }

        public DirectedEdge(T from, T to) : this(from, to, 1) { }


        public IEnumerable<T> Vertexs()
        {
            yield return BeginVertex;
            yield return EndVertex;
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var con_obj = obj as DirectedEdge<T>;
            if (con_obj == null)
                throw new ArgumentException(nameof(obj));
            return Weight.CompareTo(con_obj.Weight);
        }
    }
}