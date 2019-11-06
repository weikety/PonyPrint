using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PonyPrint.Util
{
    public class Encrypt
    {
        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Md5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, System.Web.Configuration.FormsAuthPasswordFormat.MD5.ToString());
        }
        #endregion

        //str 需要加密的字符串  
        public static String MD5(String str)
        {
            byte[] result = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder output = new StringBuilder(16);
            for (int i = 0; i < result.Length; i++)
            {
                // convert from hexa-decimal to character  
                output.Append((result[i]).ToString("x2", System.Globalization.CultureInfo.InvariantCulture));
            }
            return output.ToString();
        }

        public static  string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// 转码
        /// </summary>
        /// <param name="srcString"></param>
        /// <param name="dstEncode"></param>
        /// <returns></returns>
        public static string ConvertIso88591ToEncoding(string srcString, Encoding dstEncode)
        {
            var iso88591Encoding = Encoding.GetEncoding("ISO-8859-1");
            var gb2312Encoding = Encoding.GetEncoding("UTF-8");
            var srcBytes = iso88591Encoding.GetBytes(srcString);
            var dstBytes = Encoding.Convert(gb2312Encoding, dstEncode, srcBytes);
            var dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];
            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);
            var sResult = new string(dstChars);
            return sResult;
        }

    }
}
