using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    /// <summary>
    /// 添加打印任务请求参数
    /// </summary>
    public class PrintTaskRequest : Merchant
    {
        /// <summary>
        /// 小马平台订单号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 打印起始页码
        /// </summary>
        public int printStartPage { get; set; }
        /// <summary>
        /// 打印结束页码
        /// </summary>
        public int printEndPage { get; set; }

        //打印机设备编码与二维码 二选一

        /// <summary>
        /// 打印机设备编码
        /// </summary>
        public string printerDevSn { get; set; }
        /// <summary>
        /// 打印机设备二维码
        /// </summary>
        //public string printerCode { get; set; }

        /// <summary>
        /// 异步通知 Url 打印结果回调，POST 请求
        /// </summary>
        public string notifyUrl { get; set; }
        /// <summary>
        /// 打印份数
        /// </summary>
        public string copyCount { get; set; }
        /// <summary>
        /// 单双面  1 单面  2 双面
        /// </summary>
        public int duplexType { get; set; }
        /// <summary>
        /// 拼接方式  1 单面单页  2 单面双页  3 单面 4 页  4 单面 8 页
        /// </summary>
        public int strategyNo { get; set; }

    }
}
