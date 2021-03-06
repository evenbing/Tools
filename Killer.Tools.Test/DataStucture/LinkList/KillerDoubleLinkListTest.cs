﻿
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
            _linkList.Insert(3,4);

            _linkList.RemoveAt(2);
        }
        [TestMethod]
        public void InsertBeforeTest()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            _linkList.InsertBefore(1, random.Next(1000000));
            _linkList.InsertBefore(random.Next(1,(int)_linkList.NodeCount), random.Next(1000000));
            _linkList.InsertBefore(random.Next(1,(int)_linkList.NodeCount), random.Next(1000000));
            _linkList.InsertBefore(random.Next(1,(int)_linkList.NodeCount), random.Next(1000000));
            _linkList.InsertBefore(random.Next(1,(int)_linkList.NodeCount), random.Next(1000000));
            _linkList.InsertBefore(random.Next(1,(int)_linkList.NodeCount), random.Next(1000000));
            _linkList.InsertBefore(random.Next(1,(int)_linkList.NodeCount), random.Next(1000000));
        }
    }
}
