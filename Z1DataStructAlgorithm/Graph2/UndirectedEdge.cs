using System;
using System.Collections.Generic;

namespace Z1DataStructAlgorithm.Graph2
{
    /// <summary>
    /// 连接无向图两个顶点之间的边
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UndirectedEdge <T> :  IComparable
    {
        private readonly HashSet<T> _end_points;
        private readonly Guid _guid;

        public int Weight { get; private set; }

        public UndirectedEdge(T vertex1, T vertex2, int weight)
        {
            _end_points = new HashSet<T> {vertex1, vertex2};
            Weight = weight;
            _guid = Guid.NewGuid();
        }

        public UndirectedEdge(T vertex1, T vertex2) : this(vertex1, vertex2, 1) { }

        /// <summary>
        /// 检测参数顶点是否为边的某个顶点
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool Contain(T vertex)
        {
            return _end_points.Contains(vertex);
        }

        public bool ComposedWith(T vertex1, T vertex2)
        {
            return _end_points.Contains(vertex1) && _end_points.Contains(vertex2);
        }

        public IEnumerable<T> Vertexs()
        {
            return _end_points;
        }

        public T GetAdjoinVertex(T vertex)
        {
            foreach (var vt in _end_points)
            {
                if (!vt.Equals(vertex))
                    return vt;
            }
            return default(T);
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var con_obj = obj as UndirectedEdge<T>;
            if (con_obj == null)
                throw new ArgumentException(nameof(obj));
            return Weight.CompareTo(con_obj.Weight);
        }
    }
}