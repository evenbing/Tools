using System;
using System.Collections.Generic;

namespace Killer.Tools.DataStructure.KillerTree
{
    /// <summary>
    /// 二叉树
    /// </summary>
    public class KillerBinaryTree<T>
    {
        private KillerBinaryTreeNode<T> _root;

        public KillerBinaryTreeNode<T> Root { get => _root; set => _root = value; }

        public KillerBinaryTree()
        {

        }
        public KillerBinaryTree(T rootValue)
        {
            InitRoot(rootValue);
        }
        public void InitRoot(T value)
        {
            this._root = new KillerBinaryTreeNode<T>(value);
        }

        public void AddLeftChild(KillerBinaryTreeNode<T> node, T value)
        {
            if (this._root == null)
            {
                throw new ArgumentNullException("没有根节点");
            }
            if (node == null)
            {
                throw new ArgumentNullException("节点不能为null");
            }
            node.LeftChild = new KillerBinaryTreeNode<T>(value);
        }
        public void AddRightChild(KillerBinaryTreeNode<T> node, T value)
        {
            if (this._root == null)
            {
                throw new ArgumentNullException("没有根节点");
            }
            if (node == null)
            {
                throw new ArgumentNullException("节点不能为null");
            }
            node.RightChild = new KillerBinaryTreeNode<T>(value);
        }
        public void InsertLeft(KillerBinaryTreeNode<T> node, T value)
        {
            if (this._root == null)
            {
                throw new ArgumentNullException("没有根节点");
            }
            if (node == null)
            {
                throw new ArgumentNullException("节点不能为null");
            }
            var newnode = new KillerBinaryTreeNode<T>(value);
            newnode.LeftChild = node.LeftChild;
            node.LeftChild = newnode;
        }
        public void InsertRight(KillerBinaryTreeNode<T> node, T value)
        {
            if (this._root == null)
            {
                throw new ArgumentNullException("没有根节点");
            }
            if (node == null)
            {
                throw new ArgumentNullException("节点不能为null");
            }

            var newNode = new KillerBinaryTreeNode<T>(value, null, node.RightChild);
            node.RightChild = newNode;
        }

        /// <summary>
        /// 前序遍历 二叉树
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action">对每个节点进行的操作</param>
        public void PreTraverse(KillerBinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            action?.Invoke(node.TreeValue);
            PreTraverse(node.LeftChild, action);
            PreTraverse(node.RightChild, action);
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void MidTraverse(KillerBinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            MidTraverse(node.LeftChild, action);
            action?.Invoke(node.TreeValue);
            MidTraverse(node.RightChild, action);
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void EndTraverse(KillerBinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            EndTraverse(node.LeftChild, action);
            EndTraverse(node.RightChild, action);
            action?.Invoke(node.TreeValue);
        }
        /// <summary>
        /// 前序遍历  不使用递归
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void PreTraverseLoop(KillerBinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            Stack<KillerBinaryTreeNode<T>> stack = new Stack<KillerBinaryTreeNode<T>>(10);
            stack.Push(node);
            while (stack.Count > 0)
            {
                var midNode = stack.Pop();
                action?.Invoke(midNode.TreeValue);
                if (midNode.RightChild != null)
                {
                    stack.Push(midNode.RightChild);
                }
                if (midNode.LeftChild != null)
                {
                    stack.Push(midNode.LeftChild);
                }
            }
        }
        /// <summary>
        /// 中序遍历  非递归
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void MidTraverseLoop(KillerBinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null) return;
            Stack<KillerBinaryTreeNode<T>> stack = new Stack<KillerBinaryTreeNode<T>>(10);
            var midNode = node;
            if (midNode != null || stack.Count > 0)
            {
                while (midNode != null)
                {
                    stack.Push(midNode);
                    midNode = midNode.LeftChild;
                }
                midNode = stack.Pop();
                action?.Invoke(midNode.TreeValue);
                midNode = midNode.RightChild;
            }
        }
        /// <summary>
        /// 后序遍历二叉树  非递归
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void EndTraverseLoop(KillerBinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null) return;
            Stack<KillerBinaryTreeNode<T>> stackIn = new Stack<KillerBinaryTreeNode<T>>(10);
            Stack<KillerBinaryTreeNode<T>> stackOut = new Stack<KillerBinaryTreeNode<T>>(10);
            stackIn.Push(node);
            var midNode = node;
            while (stackIn.Count > 0)
            {
                midNode = stackIn.Pop();
                stackOut.Push(midNode);
                if (midNode.LeftChild != null)
                {
                    stackIn.Push(midNode.LeftChild);
                }
                if (midNode.RightChild != null)
                {
                    stackIn.Push(midNode.RightChild);
                }
            }
            while (stackOut.Count > 0)
            {
                midNode = stackOut.Pop();
                action?.Invoke(midNode.TreeValue);
            }
        }
        /// <summary>
        /// 层次 遍历
        /// </summary>
        /// <param name="action"></param>
        public void LevelTraverse(Action<T> action)
        {
            if (this._root == null)
            {
                return;
            }
            Queue<KillerBinaryTreeNode<T>> queue = new Queue<KillerBinaryTreeNode<T>>(10);
            queue.Enqueue(this._root);
            KillerBinaryTreeNode<T> node = null;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                action?.Invoke(node.TreeValue);
                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }
            }
        }
        /// <summary>
        /// 二叉树查找
        /// （1）若左子树不空，则左子树上所有结点的值均小于它的根结点的值；
        ///（2）若右子树不空，则右子树上所有结点的值均大于或等于它的根结点的值；
        ///（3）左、右子树也分别为二叉排序树；
        ///（4）没有键值相等的节点。
        /// </summary>
        /// <param name="value">插入的值 必须实现IComparable<T1> 接口</param>
        public void InsertWithSearch<T1>(T1 value) where T1 : IComparable<T1>
        {
            var node = new KillerBinaryTreeNode<T1>(value);
            if (typeof(T) == typeof(T1) && this._root != null)
            {
                KillerBinaryTreeNode<T1> parent = null;
                KillerBinaryTreeNode<T1> currentNode = this._root as KillerBinaryTreeNode<T1>;
                if (currentNode == null)
                {
                    return;
                }
                IComparable<T1> com;
                while (currentNode != null)
                {
                    parent = currentNode;
                    com = (IComparable<T1>)currentNode.TreeValue;
                    var res = com.CompareTo(node.TreeValue);
                    if (res < 0)
                    {
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        currentNode = currentNode.RightChild;
                    }
                }
                com = (IComparable<T1>)parent.TreeValue;
                var res1 = com.CompareTo(parent.TreeValue);
                if (res1 < 0)
                {
                    parent.LeftChild = node;
                }
                else
                {
                    parent.RightChild = node;
                }
            }

        }
    }
}
