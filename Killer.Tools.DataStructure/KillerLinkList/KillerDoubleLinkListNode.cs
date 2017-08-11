namespace Killer.Tools.DataStructure.KillerLinkList
{
    /// <summary>
    /// 双向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerDoubleLinkListNode<T>
    {
        public KillerDoubleLinkListNode()
        {

        }
        public KillerDoubleLinkListNode(T value)
        {
            this.NodeValue = value;
        }
        /// <summary>
        /// 节点值
        /// </summary>
        public T NodeValue { get; set; }
        /// <summary>
        /// 上一个节点
        /// </summary>
        public KillerDoubleLinkListNode<T> PreNode { get; set; }
        /// <summary>
        /// 下一个节点
        /// </summary>
        public KillerDoubleLinkListNode<T> NextNode { get; set; }
    }
}
