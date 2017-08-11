using Killer.Tools.DataStructure.KillerLinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Killer.Tools.Test.DataStucture.LinkList
{
    [TestClass]
    public class KillerSingleLinkListTest
    {
        KillerSingleLinkList<int> _linkList;
        [TestInitialize]
        public void Init()
        {
            _linkList = new KillerSingleLinkList<int>();
            _linkList.Add(1);
            _linkList.Add(2);
            _linkList.Add(3);
            _linkList.Add(4);
        }
        [TestMethod]
        public void AddTest()
        {
            _linkList.RemoveAt(2);
        }
        [TestMethod]
        public void KillerSingleLinkListForEach()
        {
            foreach (var item in _linkList)
            {
                Console.WriteLine(item);
            }
        }
        [TestMethod]
        public void Insert()
        {
            long index = 3;
            _linkList.Insert(index, 100);
            var node = _linkList.GetLinlistNodeByIndex(index);
            Assert.AreEqual(node.NodeValue, 100);
        }
    }
}
