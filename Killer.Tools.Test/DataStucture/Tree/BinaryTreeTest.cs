using Killer.Tools.DataStructure.KillerTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.DataStucture.Tree
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void Test()
        {
            KillerBinaryTree<int> tree = new KillerBinaryTree<int>(1);

            tree.AddLeftChild(tree.Root, 11);
            tree.AddRightChild(tree.Root, 12);
            var left = tree.Root.LeftChild;
            var right = tree.Root.RightChild;
            for (int i = 0; i < 20; i++)
            {
                if ((i & 1) == 0)
                {
                    tree.AddLeftChild(left, i);
                    tree.AddRightChild(left, i);
                    left = left.LeftChild;
                }
                else
                {
                    tree.AddLeftChild(right, i);
                    tree.AddRightChild(right, i);
                    right = right.RightChild;
                }
            }

            Console.WriteLine(11);
        }
    }
}
