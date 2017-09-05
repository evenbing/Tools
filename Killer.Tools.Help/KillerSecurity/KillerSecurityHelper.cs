using System;
using System.Security.Cryptography;
using System.Text;

namespace Killer.Tools.Help.KillerSecurity
{
    /// <summary>
    /// 各种常用加密算法实现
    /// </summary>
    public class KillerSecurityHelper
    {
        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Md5Encryption(string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "待加密字符串不能为空");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                StringBuilder sb = new StringBuilder(32);
                var res = md5.ComputeHash(encoding.GetBytes(value));
                for (int i = 0; i < res.Length; i++)
                {
                    sb.Append(res[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// SHA1 加密 
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Sha1Encryption(string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "待加密字符串不能为空");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                var strRes = Encoding.UTF8.GetBytes(value);
                strRes = sha1.ComputeHash(strRes);
                var sb = new StringBuilder();
                for (int i = 0; i < strRes.Length; i++)
                {
                    sb.Append(strRes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// SHA224 加密 
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Sha224Encryption(string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "待加密字符串不能为空");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var sha224 = HashLib.HashFactory.Crypto.CreateSHA224();
            var strRes = Encoding.UTF8.GetBytes(value);
            var res = sha224.ComputeBytes(strRes);
            strRes = res.GetBytes();
            var sb = new StringBuilder();
            for (int i = 0; i < strRes.Length; i++)
            {
                sb.Append(strRes[i].ToString("x2"));
            }
            return sb.ToString();

        }
        /// <summary>
        /// SHA256 加密 
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Sha256Encryption(string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "待加密字符串不能为空");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (SHA256 sha256 = new SHA256CryptoServiceProvider())
            {
                var strRes = Encoding.UTF8.GetBytes(value);
                strRes = sha256.ComputeHash(strRes);
                var sb = new StringBuilder();
                for (int i = 0; i < strRes.Length; i++)
                {
                    sb.Append(strRes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// SHA384 加密 
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Sha384Encryption(string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "待加密字符串不能为空");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (SHA384 sha384 = new SHA384CryptoServiceProvider())
            {
                var strRes = Encoding.UTF8.GetBytes(value);
                strRes = sha384.ComputeHash(strRes);
                var sb = new StringBuilder();
                for (int i = 0; i < strRes.Length; i++)
                {
                    sb.Append(strRes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// SHA512 加密 
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Sha512Encryption(string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "待加密字符串不能为空");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (SHA512 sha512 = new SHA512CryptoServiceProvider())
            {
                var strRes = Encoding.UTF8.GetBytes(value);
                strRes = sha512.ComputeHash(strRes);
                var sb = new StringBuilder();
                for (int i = 0; i < strRes.Length; i++)
                {
                    sb.Append(strRes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
    public enum ShaTypeEnum
    {
        None = 0,
        Sha1 = 1,
        Sha256 = 2,
        Sha224 = 3,
        Sha384 = 4,
        Sha512 = 5
    }
}
