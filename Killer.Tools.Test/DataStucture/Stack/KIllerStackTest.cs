using Killer.Tools.DataStructure.KillerStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.DataStucture.Stack
{
    [TestClass]
    public class KIllerStackTest
    {
        KillerStack<int> _stack;
        [TestInitialize]
        public void Init()
        {
            _stack = new KillerStack<int>();
        }
        [TestMethod]
        public void Test()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            var count = _stack.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(_stack.Pop());
            }
            
        }
    }
}
