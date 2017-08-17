using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            action?.Invoke(node.TreeValue);
            EndTraverse(node.RightChild, action);
        }
    }
}
