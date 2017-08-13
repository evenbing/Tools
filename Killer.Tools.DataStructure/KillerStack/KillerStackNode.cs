namespace Killer.Tools.DataStructure.KillerStack
{
    /// <summary>
    /// 栈数据节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerStackNode<T>
    {
        public T NodeValue { get; set; }
        public KillerStackNode<T> NextNode { get; set; }
        public KillerStackNode()
        {

        }
        public KillerStackNode(T value)
        {
            this.NodeValue = value;
        }
    }
}
