using System;

namespace Killer.Tools.DataStructure.KillerLinkList
{
    /// <summary>
    /// 
    /// </summary>
    public class KillerDoubleLinkList<T>
    {
        private KillerDoubleLinkListNode<T> _head;
        private KillerDoubleLinkListNode<T> _lastNode;
        private long _nodeCount;

        public long NodeCount { get => _nodeCount; set => _nodeCount = value; }


        public T this[long index]
        {
            get { return GetNodeByIndex(index).NodeValue; }
            set { GetNodeByIndex(index).NodeValue = value; }
        }
        /// <summary>
        /// 根据索引获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private KillerDoubleLinkListNode<T> GetNodeByIndex(long index)
        {
            if (index < 0 || index > this._nodeCount)
            {
                throw new IndexOutOfRangeException("索引不在链表范围内");
            }
            var node = this._head;
            for (int i = 0; i < index; i++)
            {
                node = node.NextNode;
            }
            return node;
        }
        /// <summary>
        /// 添加一个节点（放在尾部）
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            var node = new KillerDoubleLinkListNode<T>(value);
            node.PreNode = this._lastNode;
            if (this._nodeCount == 0)
            {
                this._head = node;
                this._lastNode = node;
            }
            else
            {
                this._lastNode.NextNode = node;
                this._lastNode = node;
            }
            this._nodeCount++;
        }
        /// <summary>
        /// 在任意一个位置中插入一个节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(long index, T value)
        {
            var newNode = new KillerDoubleLinkListNode<T>(value);
            if (this._nodeCount == 0)
            {
                this._head = newNode;
                this._lastNode = newNode;
            }
            else
            {
                var node = GetNodeByIndex(index - 1);
                newNode.NextNode = node;
                newNode.PreNode = node.PreNode;
                if (newNode.PreNode != null)
                {
                    newNode.PreNode.NextNode = newNode;
                }
                node.PreNode = newNode;
                if (index == 1)
                {
                    this._head = newNode;
                }
            }
            this._nodeCount++;
        }
        /// <summary>
        /// 添加在某个节点之前
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAfter(long index, T value)
        {
            if ((index != 1 && this._nodeCount == 0 && index > this._nodeCount) || index < 1)
            {
                throw new IndexOutOfRangeException("索引不在链表范围内");
            }
            if (index < this._nodeCount)
            {
                index++;
                Insert(index, value);
            }
            else
            {
                var node = new KillerDoubleLinkListNode<T>(value);
                if (this._nodeCount == 0)
                {
                    this._head = node;
                    this._lastNode = node;
                }
                else
                {
                    node.PreNode = this._lastNode;
                    this._lastNode.NextNode = node;
                    this._lastNode = node;
                }
                this._nodeCount++;
            }

        }
        public void InsertBefore(long index, T value)
        {
            if ((index != 1 && this._nodeCount == 0 && index > this._nodeCount) || index < 1)
            {
                throw new IndexOutOfRangeException("索引不在链表范围内");
            }
            if (index > 1)
            {
                index = index = 1;
                Insert(index, value);
            }
            else
            {
                var node = new KillerDoubleLinkListNode<T>(value);
                if (this._nodeCount == 0)
                {
                    this._head = node;
                    this._lastNode = node;
                }
                else
                {
                    node.NextNode = this._head;
                    this._head.PreNode = node;
                    this._head = node;
                }
                this._nodeCount++;
            }
        }
    }
}
