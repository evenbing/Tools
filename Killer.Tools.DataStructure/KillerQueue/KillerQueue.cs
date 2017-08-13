using System;

namespace Killer.Tools.DataStructure.KillerQueue
{
    /// <summary>
    /// 队列数据结构
    /// </summary>
    public class KillerQueue<T>
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
    }
}
