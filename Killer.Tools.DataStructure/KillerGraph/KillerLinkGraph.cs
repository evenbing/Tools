using System;
using System.Collections.Generic;

namespace Killer.Tools.DataStructure.KillerGraph
{
    /// <summary>
    /// 邻接表表示法 图
    /// </summary>
    public class KillerLinkGraph<T>
    {

        private HashSet<KillerVertex<T>> _vertexs;

        public HashSet<KillerVertex<T>> Vertexs { get => _vertexs; set => _vertexs = value; }

        public int Count { get => this._vertexs.Count; }

        public KillerLinkGraph()
        {
            this._vertexs = new HashSet<KillerVertex<T>>();
        }
        /// <summary>
        /// 添加一个新顶点
        /// </summary>
        /// <param name="value"></param>
        public void AddVertex(T value)
        {
            KillerVertex<T> vertex = new KillerVertex<T>(value);
            _vertexs.Add(vertex);
        }
        /// <summary>
        /// 添加一条无向边
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void AddUnDirectedEdge(KillerVertex<T> v1, KillerVertex<T> v2)
        {
            AddDirectedEdge(v1, v2);
            AddDirectedEdge(v2, v1);
        }
        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AddDirectedEdge(KillerVertex<T> from, KillerVertex<T> to)
        {
            if (from == null || to == null)
            {
                throw new ArgumentNullException("参数不能为null");
            }
            if (from.FirstEdge == null)
            {
                from.FirstEdge = new KillerLinkNode<T>(to, null);
            }
            else
            {
                var enge = from.FirstEdge;
                if (enge.Vertex == to)
                {
                    return;
                }
                while (enge.Next != null)
                {
                    enge = enge.Next;
                    if (enge.Vertex == to)
                    {
                        return;
                    }
                }
                enge.Next = new KillerLinkNode<T>(to, null);
            }
        }
        public bool IsEmpty()
        {
            return this._vertexs.Count < 1;
        }
    }
}
