using Killer.Tools.DataStructure.KillerQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.DataStucture.Queue
{
    [TestClass]
    public class KillerQueueTest
    {
        [TestMethod]
        public void QueueTest()
        {
            KillerQueue<int> queue = new KillerQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var res = queue.Dequeue();
            Assert.AreEqual(res, 1);
            res = queue.Dequeue();
            Assert.AreEqual(res, 2);
            res = queue.Dequeue();
            Assert.AreEqual(res, 3);
            Assert.AreEqual(queue.Count , 0);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
