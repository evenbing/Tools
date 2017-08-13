namespace Killer.Tools.DataStructure.KillerQueue
{
    /// <summary>
    /// 队列数据结构节点
    /// </summary>
    internal class KillerQueueNode<T>
    {
        internal KillerQueueNode<T> NextNode { get; set; }
        internal T NodeValue { get; set; }
        public KillerQueueNode() { }
        public KillerQueueNode(T value)
        {
            this.NodeValue = value;
        }
    }
}
