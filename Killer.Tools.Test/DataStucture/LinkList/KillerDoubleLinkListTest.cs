
using Killer.Tools.DataStructure.KillerLinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.DataStucture.LinkList
{
    [TestClass]
    public class KillerDoubleLinkListTest
    {
        KillerDoubleLinkList<int> _linkList;
        [TestInitialize]
        public void Init()
        {
            _linkList = new KillerDoubleLinkList<int>();
        }
        [TestMethod]
        public void AddTest()
        {
            _linkList.Add(1);
            _linkList.Add(2);
            _linkList.Add(3);

        }
        [TestMethod]
        public void Insert()
        {
            _linkList.Insert(0,1);
            _linkList.Insert(1,2);
            _linkList.Insert(2,3);
        }
    }
}
