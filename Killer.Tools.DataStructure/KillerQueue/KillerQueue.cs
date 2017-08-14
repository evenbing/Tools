using System;
using System.Collections;
using System.Collections.Generic;

namespace Killer.Tools.DataStructure.KillerQueue
{
    /// <summary>
    /// 队列数据结构
    /// </summary>
    public class KillerQueue<T> : IEnumerable<T>
    {
        private KillerQueueNode<T> _head;
        private KillerQueueNode<T> _end;
        private long _count;

        public long Count { get => _count; set => _count = value; }

        /// <summary>
        /// 向队列中添加一个数据
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            var node = new KillerQueueNode<T>(value);
            if (this._count == 0)
            {
                this._head = node;
                this._end = node;
            }
            else
            {
                this._end.NextNode = node;
                this._end = node;
            }
            this._count++;
        }
        /// <summary>
        /// 从对列中取出一个值
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (this._count < 1)
            {
                throw new IndexOutOfRangeException("队列中的数据为空");
            }
            var node = this._head;
            this._head = this._head.NextNode;
            node.NextNode = null;
            this._count--;
            if (this._count == 0)
            {
                this._end = null;
            }
            return node.NodeValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new KillerQueueEnumerator(this._head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public struct KillerQueueEnumerator : IEnumerator<T>
        {
            internal KillerQueueEnumerator(KillerQueueNode<T> node)
            {
                this._node = node;
                this._nodeFirst = node;
            }
            private KillerQueueNode<T> _node;
            private KillerQueueNode<T> _nodeFirst;
            public T Current
            {
                get
                {
                    var node = this._node;
                    this._node = node.NextNode;
                    return node.NodeValue;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    var node = this._node;
                    this._node = node.NextNode;
                    return node.NodeValue;
                }
            }

            public void Dispose()
            {
                this._node = null;
            }

            public bool MoveNext()
            {
                return this._node != null;

            }

            public void Reset()
            {
                this._node = this._nodeFirst;
            }
        }
    }
}
