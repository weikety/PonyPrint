using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    public class ScanRequest : Merchant
    {
        /// <summary>
        /// 扫描类型， 2 单页扫描,3 连续扫描 6 身份证扫描
        /// </summary>
        public string scanType { get; set; }

        /// <summary>
        /// 打印机编号 SN
        /// </summary>
        public string printerDevSn { get; set; }

        /// <summary>
        /// 第三方商户的扫描编号
        /// </summary>
        public string thirdScanNo { get; set; }

        /// <summary>
        /// 扫描异步通知地址，POST 请求
        /// </summary>
        public string scanNotifyUrl { get; set; }

    }
}
