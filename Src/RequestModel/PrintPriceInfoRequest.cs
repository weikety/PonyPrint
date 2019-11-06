using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    /// <summary>
    /// 打印机信息查询请求参数
    /// </summary>
    public class PrintPriceInfoRequest : Merchant
    {
        //打印点的id和打印机的SN号 必传，二选一，建议使用serviceStationId

        /// <summary>
        /// 打印点的 id
        /// </summary>
        public long serviceStationId { get; set; }
        /// <summary>
        /// 打印机的 SN 号
        /// </summary>
        public string printerDevSn { get; set; }
        /// <summary>
        /// 打印开始的页码
        /// </summary>
        public string printStartPage { get; set; }
        /// <summary>
        /// 打印结束的页码
        /// </summary>
        public string printEndPage { get; set; }
        /// <summary>
        /// 打印的份数
        /// </summary>
        public string copyCount { get; set; }
        /// <summary>
        /// 单双面：1，单面；2，双面
        /// </summary>
        public string duplexType { get; set; }
        /// <summary>
        /// 拼接方式：1，单拼；2，双拼；3，4 拼；4，8 拼
        /// </summary>
        public string strategyNo { get; set; }

    }
}
