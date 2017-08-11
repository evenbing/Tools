using System;
using System.Collections;
using System.Collections.Generic;

namespace Killer.Tools.DataStructure.KillerLinkList
{
    /// <summary>
    /// 单向链表
    /// </summary>
    public class KillerSingleLinkList<T> : IEnumerable<T>, IEnumerator<T>
    {
        public KillerSingleLinkList()
        {
            this.NodeCount = 0;
        }
        /// <summary>
        /// 头结点
        /// </summary>
        private KillerLinkListNode<T> _head;
        /// <summary>
        /// 最后一个节点
        /// </summary>
        private KillerLinkListNode<T> _lastNode;
        private long _nodeCount;
        /// <summary>
        /// 在节点尾部添加一个节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            KillerLinkListNode<T> node = new KillerLinkListNode<T>(value);
            if (this._head == null)
            {
                this._head = node;
                this._lastNode = node;
            }
            else
            {
                this._lastNode.NextNode = node;
                this._lastNode = node;
            }
            this.NodeCount++;
        }
        /// <summary>
        /// 在任意位置插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(long index, T value)
        {
            this._nodeCount++;
            var newNode = new KillerLinkListNode<T>(value);
            if (index == 0)
            {
                newNode.NextNode = this._head;
                this._head = newNode;
            }
            else
            {
                var node = this.GetLinlistNodeByIndex(index - 1);
                newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
            }
        }
        /// <summary>
        /// 根据索引查找节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public KillerLinkListNode<T> GetLinlistNodeByIndex(long index)
        {
            if (index < 0 || index > this._nodeCount)
            {
                throw new IndexOutOfRangeException("索引不在链表的范围内");
            }
            var node = this._head;
            for (int i = 0; i < index; i++)
            {
                node = node.NextNode;
            }
            return node;
        }
        /// <summary>
        /// 移除链表中任意一个元素
        /// </summary>
        /// <param name="index">所在位置</param>
        public void RemoveAt(long index)
        {
            if (index < 0 || index > this._nodeCount)
            {
                throw new IndexOutOfRangeException("索引不在链表的范围内");
            }
            if (index == this._nodeCount)
            {
                if (this._nodeCount == 1)
                {
                    this._lastNode = null;
                }
                else
                {
                    var node1 = GetLinlistNodeByIndex(index - 1);
                    this._lastNode = node1;
                }
            }
            if (index == 0)
            {
                this._head = this._head.NextNode;
            }
            else
            {
                var node = GetLinlistNodeByIndex(index - 1);
                var next = node.NextNode;
                node.NextNode = next.NextNode;
                next = null;
            }
            this.NodeCount--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._head = null;
            this._lastNode = null;
            this._nodeCount = 0;
        }

        public bool MoveNext()
        {
            this._moveIndex++;
            if (this._moveIndex <= this._nodeCount )
            {
                if (this._moveIndex == 0)
                {
                    this._currentNode = this._head;
                }
                else
                {
                    this._currentNode = this._currentNode.NextNode;
                }
            }
            return this._currentNode != null;
        }

        public void Reset()
        {
            this.Dispose();
        }
        /// <summary>
        /// 节点数量
        /// </summary>
        public long NodeCount { get => _nodeCount; set => _nodeCount = value; }
        /// <summary>
        /// 当前值
        /// </summary>
        public T Current => this._currentNode.NodeValue;
        private T _current;
        private KillerLinkListNode<T> _currentNode;
        private long _moveIndex = -1;
        object IEnumerator.Current => this._currentNode.NodeValue;
    }
}
