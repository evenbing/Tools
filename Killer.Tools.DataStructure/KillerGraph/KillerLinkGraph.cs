﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="weigth"></param>
        public void AddUnDirectedEdge(KillerVertex<T> v1, KillerVertex<T> v2, int weigth = 0)
        {
            AddDirectedEdge(v1, v2, weigth);
            AddDirectedEdge(v2, v1, weigth);
        }
        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="weigth"></param>
        public void AddDirectedEdge(KillerVertex<T> from, KillerVertex<T> to, int weigth = 0)
        {
            if (from == null || to == null)
            {
                throw new ArgumentNullException("参数不能为null");
            }
            if (weigth < 0)
            {
                weigth = 0;
            }
            var midEdge = to.FirstEdge;
            if (midEdge != null)
            {
                do
                {
                    if (midEdge.Vertex == from)
                    {
                        if (midEdge.Weight != weigth)
                        {
                            throw new InvalidOperationException("两个节点之间的权重不一致");
                        }
                    }
                    midEdge = midEdge.Next;
                } while (midEdge != null);
            }
            if (from.FirstEdge == null)
            {
                from.FirstEdge = new KillerLinkNode<T>(to, null, weigth);
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
                enge.Next = new KillerLinkNode<T>(to, null, weigth);
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
                from.FirstEdge = from.FirstEdge.Next;
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
        /// <summary>
        /// 深度优先遍历
        /// </summary>
        public void DepthTraverse(KillerVertex<T> startVertex, Action<KillerVertex<T>> vertexDo)
        {
            InitVisited();//初始化为未访问过的
            if (startVertex == null)
            {
                throw new ArgumentNullException("startVertex", "其实顶点不能为null");
            }
            DepthTraverseIn(startVertex, vertexDo);
        }

        private void DepthTraverseIn(KillerVertex<T> startVertex, Action<KillerVertex<T>> vertexDo)
        {
            var midVertex = startVertex;
            var edge = midVertex.FirstEdge;
            var queue = new Queue<KillerVertex<T>>((int)(this.Count / 2));
            queue.Enqueue(midVertex);
            while (queue.Count > 0)
            {
                midVertex = queue.Dequeue();
                if (midVertex.IsVisited == false)
                {
                    vertexDo?.Invoke(midVertex);
                    midVertex.IsVisited = true;
                }
                edge = midVertex.FirstEdge;
                while (edge != null)
                {
                    while (!edge.Vertex.IsVisited)
                    {
                        vertexDo?.Invoke(edge.Vertex);
                        edge.Vertex.IsVisited = true;
                        queue.Enqueue(edge.Vertex);
                        edge = edge.Vertex.FirstEdge;
                    }
                    edge = edge?.Next;
                }
            }
            //while (edge != null)
            //{
            //    while (!midVertex.IsVisited)
            //    {
            //        vertexDo?.Invoke(midVertex);
            //        midVertex.IsVisited = true;
            //        midVertex = edge.Vertex;
            //        if (edge.Next == null)
            //        {
            //            edge = edge.Vertex.FirstEdge;
            //            break;
            //        }
            //        else
            //        {
            //            edge = edge.Next;
            //        }
            //    }
            //    edge = edge?.Next;
            //}
        }

        /// <summary>
        /// 广度优先遍历 图
        /// </summary>
        /// <param name="startVertex"></param>
        /// <param name="vertexDo"></param>
        public void BreadthTraverse(KillerVertex<T> startVertex, Action<KillerVertex<T>> vertexDo)
        {
            if (startVertex == null)
            {
                throw new ArgumentNullException("startVertex", "遍历起始节点不能为null");
            }
            InitVisited();
            BreadthTraverseIn(startVertex, vertexDo);
        }

        private void BreadthTraverseIn(KillerVertex<T> startVertex, Action<KillerVertex<T>> vertexDo)
        {
            var queue = new Queue<KillerVertex<T>>(this.Count);
            queue.Enqueue(startVertex);
            var edge = startVertex.FirstEdge;
            KillerVertex<T> vertex;
            while (queue.Count > 0)
            {
                vertex = queue.Dequeue();
                if (!vertex.IsVisited)
                {
                    vertex.IsVisited = true;
                    vertexDo?.Invoke(vertex);
                }
                edge = vertex.FirstEdge;
                while (edge != null)
                {
                    if (edge.Vertex.IsVisited == false)
                    {
                        vertexDo?.Invoke(edge.Vertex);
                        edge.Vertex.IsVisited = true;
                        queue.Enqueue(edge.Vertex);
                    }
                    edge = edge.Next;
                }
            }
        }

        /// <summary>
        /// 非全向 图 深度优先遍历
        /// </summary>
        /// <param name="vertexDo"></param>
        public void NotAllDirectedDepth(Action<KillerVertex<T>> vertexDo)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("图中没有数据");
            }
            InitVisited();

            foreach (var vertex in this._vertexs)
            {
                DepthTraverseIn(vertex, vertexDo);
            }
        }
        /// <summary>
        /// 非全向图 广度优先遍历
        /// </summary>
        /// <param name="vertexDo"></param>
        public void NotAllDirectedBreadth(Action<KillerVertex<T>> vertexDo)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("图中没有数据");
            }
            InitVisited();

            foreach (var vertex in this._vertexs)
            {
                BreadthTraverseIn(vertex, vertexDo);
            }
        }
        /// <summary>
        /// prim  最短树选择
        /// </summary>
        /// <param name="startVertex"></param>
        /// <returns></returns>
        public KillerLinkGraph<T> PrimTree(KillerVertex<T> startVertex)
        {
            if (IsEmpty())
            {
                return null;
            }
            if (startVertex == null)
            {
                startVertex = this._vertexs.First();
            }
            KillerLinkGraph<T> graph = new KillerLinkGraph<T>();
            graph.AddVertex(startVertex.VertexValue);
            var midEdge = startVertex.FirstEdge;
            var midVertex = startVertex;
            var fromVertex = startVertex;
            HashSet<KillerVertex<T>> hashSet = new HashSet<KillerVertex<T>>();
            hashSet.Add(startVertex);
            Dictionary<KillerVertex<T>, KillerLinkNode<T>> dic = new Dictionary<KillerVertex<T>, KillerLinkNode<T>>(this.Count * 2);
            Dictionary<KillerVertex<T>, KillerLinkNode<T>> dicMid = new Dictionary<KillerVertex<T>, KillerLinkNode<T>>(this.Count);
            while (hashSet.Count < this.Count)
            {
                var weight = int.MaxValue;
                foreach (var item in hashSet)
                {
                    fromVertex = item;
                    midEdge = item.FirstEdge;
                    midVertex = midEdge.Vertex;
                    dicMid.Add(fromVertex, midEdge);
                    do
                    {
                        if (midEdge.Weight <= weight && !hashSet.Contains(midEdge.Vertex))
                        {
                            midVertex = midEdge.Vertex;
                            weight = midEdge.Weight;
                            dicMid[fromVertex] = midEdge;
                        }
                        midEdge = midEdge.Next;
                    } while (midEdge != null);
                }
                if (dicMid.Count == 1)
                {
                    var res = dicMid.First();
                    Console.WriteLine($"{res.Key.VertexValue}----{res.Value.Vertex.VertexValue}-----weigth{weight}");
                    hashSet.Add(res.Value.Vertex);
                }
                else
                {
                    foreach (var item in dicMid)
                    {
                        if (item.Value.Weight == weight)
                        {
                            hashSet.Add(item.Value.Vertex);
                            Console.WriteLine($"{item.Key.VertexValue}----{item.Value.Vertex.VertexValue}-----weigth{weight}");
                            break;
                        }
                    }
                }
                dicMid = new Dictionary<KillerVertex<T>, KillerLinkNode<T>>();
            }
            return null;
        }
        /// <summary>
        /// Kruska 最短树生成算法
        /// </summary>
        public void KruskalMinTree()
        {
            //
            List<KillerGraphEdge<T>> list = new List<KillerGraphEdge<T>>(this.Count * this.Count - this.Count);
            foreach (var vertex in this._vertexs)
            {
                var edge = vertex.FirstEdge;

                do
                {
                    list.Add(new KillerGraphEdge<T>()
                    {
                        BeginVertex = vertex,
                        EndVertex = edge.Vertex,
                        Weight = edge.Weight
                    });
                    edge = edge.Next;
                } while (edge != null);
            }
            list.Sort();
            Dictionary<int, List<KillerGraphEdge<T>>> groups = new Dictionary<int, List<KillerGraphEdge<T>>>(this.Count);
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var mark = true;
                if (groups.Count < 1)
                {
                    groups.Add(i, new List<KillerGraphEdge<T>>(this.Count) { item });
                    Console.WriteLine($"{item.BeginVertex.VertexValue} --  {item.EndVertex.VertexValue}  weight : {item.Weight}");
                }
                else
                {
                    foreach (var group in groups)
                    {
                        for (int ik = 0; ik < group.Value.Count; ik++)
                        {
                            if (group.Value[ik].EndVertex == item.EndVertex || group.Value[ik].EndVertex == item.BeginVertex || group.Value[ik].BeginVertex == item.EndVertex || group.Value[ik].BeginVertex == item.BeginVertex)
                            {
                                if (group.Value[ik].EndVertex == item.BeginVertex && group.Value[ik].BeginVertex == item.EndVertex)
                                {
                                    mark = false;
                                    break;
                                }
                                int key1 = -1;
                                int key2 = -1;
                                bool flag1 = false;
                                bool flag2 = false;
                                //mark = false;
                                //Console.WriteLine($"{item.BeginVertex.VertexValue} --  {item.EndVertex.VertexValue}  weight : {item.Weight}");
                                //groups[group.Key].Add(item);
                                flag1 = groups.Any(t =>
                                    {
                                        key1 = t.Key;
                                        return t.Value.Any(k =>
                                        {
                                            return k.BeginVertex == item.BeginVertex || k.EndVertex == item.BeginVertex;
                                        });
                                    });
                                flag2 = groups.Any(t =>
                                  {
                                      key2 = t.Key;
                                      return t.Value.Any(k =>
                                      {
                                          return k.BeginVertex == item.EndVertex || k.EndVertex == item.EndVertex;
                                      });
                                  });
                                if (flag2 && flag1)
                                {
                                    if (key1 != key2)
                                    {
                                        groups[key1].AddRange(groups[key2]);
                                        groups.Remove(key2);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"*{item.BeginVertex.VertexValue} --  {item.EndVertex.VertexValue}  weight : {item.Weight}");
                                    //得判断联通
                                    if (flag1)
                                    {
                                        groups[key1].Add(item);
                                    }
                                    if (flag2)
                                    {
                                        groups[key2].Add(item);
                                    }
                                }
                                mark = false;
                                break;
                            }
                        }
                        if (mark)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (mark)
                    {
                        groups.Add(i, new List<KillerGraphEdge<T>>(this.Count) { item });
                        Console.WriteLine($"+{item.BeginVertex.VertexValue} --  {item.EndVertex.VertexValue}  weight : {item.Weight}");
                    }
                }
            }
        }

        private void InitVisited()
        {
            foreach (var vertex in this._vertexs)
            {
                vertex.IsVisited = false;
            }
        }
        public bool IsEmpty()
        {
            return this._vertexs.Count < 1;
        }
    }
}
