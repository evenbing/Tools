using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Killer.Tools.Help.KillerSecurity
{
    /// <summary>
    /// 常见对称加密封装
    /// </summary>
    public class KillerSymmetricalEncryptionHelper
    {
        public static Encoding EncryptionEncoding { get => Encoding.UTF8; }

        private static byte[] _desIv = { 0x01, 0x56, 0x33, 0x89, 0x54, 0x41, 0x91, 0x37 };
        private static byte[] _aesIv = { 0x01, 0x56, 0x33, 0x89, 0x54, 0x41, 0x91, 0x37, 0x01, 0x56, 0x33, 0x89, 0x54, 0x41, 0x91, 0x37 };
        /// <summary>
        /// des 加密
        /// </summary>
        /// <param name="value">待加密内容</param>
        /// <param name="secretKey">加密key</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string DesEncryption(string value, string secretKey, Encoding encoding = null, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Encryption content is empty");
            }
            if (encoding == null)
            {
                encoding = EncryptionEncoding;
            }
            using (DES des = new DESCryptoServiceProvider()
            {
                IV = _desIv,
                Key = SetSecretKey(secretKey, 8, encoding),
                Mode = mode,
                Padding = padding
            })
            {
                var creator = des.CreateEncryptor();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, creator, CryptoStreamMode.Write);
                var inputvalue = encoding.GetBytes(value);
                cryptoStream.Write(inputvalue, 0, inputvalue.Length);
                cryptoStream.FlushFinalBlock();
                var res = memoryStream.ToArray();
                StringBuilder sb = new StringBuilder(res.Length * 2);
                for (int i = 0; i < res.Length; i++)
                {
                    sb.Append(res[i].ToString("X2"));
                }
                cryptoStream.Dispose();
                memoryStream.Dispose();
                return sb.ToString();
            }
        }
        /// <summary>
        /// des 解密
        /// </summary>
        /// <param name="value">待解密内容</param>
        /// <param name="secretKey">加密key</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string DesDeEncryption(string value, string secretKey, Encoding encoding = null, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Encryption content is empty");
            }
            if (encoding == null)
            {
                encoding = EncryptionEncoding;
            }
            using (DES des = new DESCryptoServiceProvider()
            {
                IV = _desIv,
                Key = SetSecretKey(secretKey, 8, encoding),
                Mode = mode,
                Padding = padding
            })
            {
                var creator = des.CreateDecryptor();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, creator, CryptoStreamMode.Write);
                byte[] inputByteArray = new byte[value.Length / 2];
                for (int x = 0; x < value.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(value.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();
                var res = memoryStream.ToArray();
                var desStr = encoding.GetString(res);
                cryptoStream.Dispose();
                memoryStream.Dispose();
                return desStr;
            }
        }
        /// <summary>
        /// 3des  加密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="secretKey"></param>
        /// <param name="encoding"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string Des3Encryption(string value, string secretKey, Encoding encoding = null, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Encryption content is empty");
            }
            if (encoding == null)
            {
                encoding = EncryptionEncoding;
            }
            using (TripleDES des3 = new TripleDESCryptoServiceProvider()
            {
                Key = SetSecretKey(secretKey, 24, encoding),
                IV = _desIv,
                Mode = mode,
                Padding = padding
            })
            {
                var creator = des3.CreateEncryptor();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, creator, CryptoStreamMode.Write);
                var inputvalue = encoding.GetBytes(value);
                cryptoStream.Write(inputvalue, 0, inputvalue.Length);
                cryptoStream.FlushFinalBlock();
                var res = memoryStream.ToArray();
                StringBuilder sb = new StringBuilder(res.Length * 2);
                for (int i = 0; i < res.Length; i++)
                {
                    sb.Append(res[i].ToString("X2"));
                }
                cryptoStream.Dispose();
                memoryStream.Dispose();
                return sb.ToString();
            }
        }
        /// <summary>
        /// 3DES 解密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="secretKey"></param>
        /// <param name="encoding"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string Des3DeEncryption(string value, string secretKey, Encoding encoding = null, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Encryption content is empty");
            }
            if (encoding == null)
            {
                encoding = EncryptionEncoding;
            }
            using (TripleDES des3 = new TripleDESCryptoServiceProvider()
            {
                Key = SetSecretKey(secretKey, 24, encoding),
                IV = _desIv,
                Mode = mode,
                Padding = padding
            })
            {
                var creator = des3.CreateDecryptor();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, creator, CryptoStreamMode.Write);
                byte[] inputvalue = new byte[value.Length / 2];
                for (int x = 0; x < value.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(value.Substring(x * 2, 2), 16));
                    inputvalue[x] = (byte)i;
                }
                cryptoStream.Write(inputvalue, 0, inputvalue.Length);
                cryptoStream.FlushFinalBlock();
                var res = memoryStream.ToArray();
                var desStr = encoding.GetString(res);
                cryptoStream.Dispose();
                memoryStream.Dispose();
                return desStr;
            }
        }
        /// <summary>
        /// Aes 加密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="secretKey"></param>
        /// <param name="keySize"></param>
        /// <param name="encoding"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static string AESEncryption(string value, string secretKey, AESLen keySize = AESLen.Len128, Encoding encoding = null, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Encryption content is empty");
            }
            if (encoding == null)
            {
                encoding = EncryptionEncoding;
            }

            using (Aes aes = new AesCryptoServiceProvider()
            {
                IV = _aesIv,
                Mode = mode,
                Padding = padding,
                KeySize = (int)keySize,
                Key = SetSecretKey(secretKey, 16, encoding)
            })
            {
                var creator = aes.CreateEncryptor();
                var inputvalue = encoding.GetBytes(value);
                var res = creator.TransformFinalBlock(inputvalue, 0, inputvalue.Length);
                StringBuilder sb = new StringBuilder(res.Length * 2);
                for (int i = 0; i < res.Length; i++)
                {
                    sb.Append(res[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="secretKey"></param>
        /// <param name="keySize"></param>
        /// <param name="encoding"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static string AESDeEncryption(string value, string secretKey, AESLen keySize = AESLen.Len128, Encoding encoding = null, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Encryption content is empty");
            }
            if (encoding == null)
            {
                encoding = EncryptionEncoding;
            }
            using (Aes aes = new AesCryptoServiceProvider()
            {
                IV = _aesIv,
                Mode = mode,
                Padding = padding,
                KeySize = (int)keySize,
                Key = SetSecretKey(secretKey, 16, encoding)
            })
            {
                var creator = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] inputvalue = new byte[value.Length / 2];
                for (int x = 0; x < value.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(value.Substring(x * 2, 2), 16));
                    inputvalue[x] = (byte)i;
                }
                var res = creator.TransformFinalBlock(inputvalue, 0, inputvalue.Length);
                return encoding.GetString(res);
            }
        }

        private static byte[] SetSecretKey(string secretKey, int len, Encoding encoding)
        {
            var SecretKey = encoding.GetBytes(secretKey);
            if (SecretKey.Length > len)
            {
                byte[] keys = new byte[len];
                Array.Copy(SecretKey, keys, keys.Length);
                return keys;
            }
            else
            {
                return SecretKey;
            }
        }

    }
    public enum AESLen
    {
        Len128 = 128,
        Len192 = 192,
        Len256 = 256
    }
}
