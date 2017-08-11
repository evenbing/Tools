namespace Killer.Tools.DataStructure.KillerLinkList
{
    /// <summary>
    /// 单向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerLinkListNode<T>
    {
        public T NodeValue { get; set; }
        public KillerLinkListNode<T> NextNode { get; set; }
        public KillerLinkListNode() : this(default(T))
        { }
        public KillerLinkListNode(T value)
        {
            this.NodeValue = value;
        }
    }
}
