﻿using Killer.Tools.Help.KillerSecurity;
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


        }
    }
}
