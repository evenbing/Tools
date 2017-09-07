using Killer.Tools.Help.KillerSecurity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.Help.Security
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class KillerSymmetricalEncryptionHelperTest
    {
        [TestMethod]
        public void Des( )
        {
            string key = "123456781234567812345678";
            string value = "中国";
            var res1=KillerSymmetricalEncryptionHelper.DesEncryption(value, key);
            Console.WriteLine(res1);
            var res2 = KillerSymmetricalEncryptionHelper.DesDeEncryption(res1, key);
            Console.WriteLine(res2);

            Assert.AreEqual(value, res2);
        }
        [TestMethod]
        public void DES3()
        {
            string key = "jskjdpps90dsdks%$#555&*()12345678123456780000000025556";
            string value = "中国";
            var res1 = KillerSymmetricalEncryptionHelper.Des3Encryption(value, key);
            Console.WriteLine(res1);
            var res2 = KillerSymmetricalEncryptionHelper.Des3DeEncryption(res1, key);
            Console.WriteLine(res2);

            Assert.AreEqual(value, res2);
        }
        [TestMethod]
        public void AES()
        {
            //7CA69DEE25F5EB830E3D849340C004C4
            //66021339B8929620F6397D070E508707
            string key = "jskjdpps90dsdks%$#555&*()12345678123456780000000025556";
            string value = "中国354656565465dsdkjsjkkjdbsmndbsjcvbsdvfd";
            var res1 = KillerSymmetricalEncryptionHelper.AESEncryption(value, key,AESLen.Len256);
            Console.WriteLine(res1);
            var res2 = KillerSymmetricalEncryptionHelper.AESDeEncryption(res1, key, AESLen.Len256);
            Console.WriteLine(res2);
        }
    }
}
