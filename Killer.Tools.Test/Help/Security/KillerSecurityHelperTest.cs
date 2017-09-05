using Killer.Tools.Help.KillerSecurity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Killer.Tools.Test.Help.Security
{
    [TestClass]
    public class KillerSecurityHelperTest
    {
        [TestMethod]
        public void Md5EncryptionTest()
        {
            string str = "123";
            var res = KillerSecurityHelper.Md5Encryption(str);
            Assert.AreEqual(32, res.Length);
        }
        [TestMethod]
        public void Sha1EncryptionTest()
        {
            string str = "123";
            var res = KillerSecurityHelper.Sha1Encryption(str);
            Console.WriteLine(res);
            str = "40bd001563085fc35165329ea1ff5c5ecbdbbeef";
        }
        [TestMethod]
        public void Sha224EncryptionTest()
        {
            string str = "12300";
            var res = KillerSecurityHelper.Sha224Encryption(str);
            Console.WriteLine(res);
            str = "6b4e03423667dbb73b6e15454f0eb1abd4597f9a1b078e3f5b5a6bc7";
            //Assert.AreEqual(224, res.Length);
        }

    }
}
