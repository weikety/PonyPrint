using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.Util
{
    public class Tool
    {
        #region 获取signStr签名之后的提交数据
        /// <summary>
        /// ASCII排序MD5
        /// </summary>
        /// <param name="obj">参数对象</param>
        /// <returns></returns>
        public static string GetAsciiSortMd5Post(object obj)
        {
            var ht = new Hashtable();
            var propertyInfo = obj.GetType().GetProperties();
            foreach (var item in propertyInfo)
            {
                var objectValue = item.GetGetMethod().Invoke(obj, null);
                if (!string.IsNullOrEmpty(objectValue?.ToString()))
                {
                    ht.Add(item.Name, objectValue.ToString());
                }
            }
            var sb = new StringBuilder();
            var tempAkeys = new ArrayList(ht.Keys);
            //arraylist转array
            var akeys = new string[tempAkeys.Count];
            tempAkeys.CopyTo(akeys);
            //区分大小写设置进行排序
            Array.Sort(akeys, StringComparer.Ordinal);

            foreach (var k in akeys)
            {
                string v;
                if (null == ht[k])
                {
                    v = (string)ht[k];
                }
                else
                {
                    v = ht[k].ToString();
                }
                if (!string.IsNullOrEmpty(v))
                {
                    sb.Append($"{k}={v}&");
                }
            }
            var temp = sb.ToString();
            string signstr = Encrypt.getMd5Hash(sb+ Config.AppSecret).ToLower();
            string xxx = Encrypt.getMd5Hash("123456").ToLower();
            temp = temp +($"signStr={signstr}");
            return temp;
        }
        #endregion

        #region 获取提交参数字符串
        /// <summary>
        /// 获取提交参数字符串(需要设置sign签名)
        /// </summary>
        /// <param name="obj">参数对象</param>
        /// <returns></returns>
        public static string GetPostData(object obj)
        {
            var sb = new StringBuilder();
            var propertyInfo = obj.GetType().GetProperties();
            foreach (var item in propertyInfo)
            {
                var objectValue = item.GetGetMethod().Invoke(obj, null);
                if (objectValue!=null && objectValue.ToString() != "")
                {
                    sb.Append(item.Name.ToLower() + "=" + objectValue + "&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
        #endregion

    }
}
