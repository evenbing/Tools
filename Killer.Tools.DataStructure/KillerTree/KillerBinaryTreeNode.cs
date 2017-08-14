namespace Killer.Tools.DataStructure.KillerTree
{
    /// <summary>
    /// 二叉树 节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerBinaryTreeNode<T>
    {
        public T TreeValue { get; set; }
        /// <summary>
        /// 左孩子
        /// </summary>
        public KillerBinaryTreeNode<T> LeftChild { get; set; }
        /// <summary>
        /// 右孩子
        /// </summary>
        public KillerBinaryTreeNode<T> RightChild { get; set; }
        public KillerBinaryTreeNode(T value)
        {
            this.TreeValue = value;
        }
        public KillerBinaryTreeNode(T value, KillerBinaryTreeNode<T> leftChild, KillerBinaryTreeNode<T> rightChild)
        {
            this.TreeValue = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
    }
}
