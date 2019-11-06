using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    /// <summary>
    /// 文件转换请求参数
    /// </summary>
    public class TransferRequest : Merchant
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 文件可访问的 Url
        /// </summary>
        public string srcUrl { get; set; }
        /// <summary>
        /// 文件 MD5
        /// </summary>
        public string md5 { get; set; }
        /// <summary>
        /// 第三方自定义参数，要求唯一
        /// </summary>
        public string clientParam { get; set; }
        /// <summary>
        /// 异步通知 Url 转换后回调，POST 请求
        /// </summary>
        public string notifyUrl { get; set; }
        
    }
}
