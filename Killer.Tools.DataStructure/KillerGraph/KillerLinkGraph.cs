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
        /// <summary>
        /// 移除一个顶点
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool RemoveVertex(KillerVertex<T> vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException("vertex is null");
            }
            if (this._vertexs.Contains(vertex))
            {
                //解除边
                foreach (var item in this._vertexs)
                {
                    if (item == vertex)
                    {
                        continue;
                    }
                    RemoveDirectedEdge(item, vertex);
                }
                return this._vertexs.Remove(vertex);
            }
            return false;
        }
        /// <summary>
        /// 删除特定条件下的顶点
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool RemoveVertex(Predicate<KillerVertex<T>> filter)
        {
            if (filter == null)
            {
                return false;
            }
            List<KillerVertex<T>> removed = new List<KillerVertex<T>>(10);
            foreach (var item in this._vertexs)
            {
                if (filter(item))
                {
                    removed.Add(item);
                }
            }
            if (removed.Count < 1)
            {
                return false;
            }
            foreach (var item in this._vertexs)
            {
                foreach (var remove in removed)
                {
                    if (item == remove)
                    {
                        continue;
                    }
                    RemoveDirectedEdge(item, remove);
                }
            }
            return this._vertexs.RemoveWhere(filter) > 0;
        }
        /// <summary>
        /// 删除无向边
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool RemoveUnDirectedEdge(KillerVertex<T> v1, KillerVertex<T> v2)
        {
            var flag = RemoveDirectedEdge(v1, v2);
            var flag2 = RemoveDirectedEdge(v2, v1);
            return flag || flag2;
        }
        /// <summary>
        /// 移除一个有向边
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool RemoveDirectedEdge(KillerVertex<T> from, KillerVertex<T> to)
        {
            if (from == null || to == null)
            {
                throw new ArgumentNullException("参数不能为null");
            }
            if (from.FirstEdge == null)
            {
                return false;
            }
            if (from.FirstEdge.Vertex == to)
            {
                from.FirstEdge = null;
                return true;
            }
            var edge = from.FirstEdge;
            var pre = from.FirstEdge;
            while (edge.Next != null)
            {
                pre = edge;
                edge = edge.Next;
                if (edge.Vertex == to)
                {
                    pre.Next = edge.Next;
                    return true;
                }
            }
            return false;
        }
        public bool IsEmpty()
        {
            return this._vertexs.Count < 1;
        }
    }
}
