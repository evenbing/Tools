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
            str = "78d8045d684abd2eece923758f3cd781489df3a48e1278982466017f";
            //Assert.AreEqual(224, res.Length);
        }

    }
}
