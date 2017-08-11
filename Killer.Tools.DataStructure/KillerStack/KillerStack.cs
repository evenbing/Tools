using System;

namespace Killer.Tools.DataStructure.KillerStack
{
    /// <summary>
    /// 栈 数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerStack<T>
    {
        private long _count;
        /// <summary>
        /// 栈中数据数量
        /// </summary>
        public long Count { get => _count; set => _count = value; }
        private KillerStackNode<T> _head;
        /// <summary>
        /// 压入一个数据进栈
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            var node = new KillerStackNode<T>(value);
            if (this._count == 0)
            {
                this._head = node;
            }
            else
            {
                node.NextNode = this._head;
                this._head = node;
            }
            this._count++;
        }
        /// <summary>
        /// 从栈中弹出一个数据 
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (this._count < 1)
            {
                throw new ArgumentNullException("栈中没有数据");
            }
            var node = this._head;
            this._head = this._head.NextNode;
            this._count--;
            return node.NodeValue;
        }
    }
}
