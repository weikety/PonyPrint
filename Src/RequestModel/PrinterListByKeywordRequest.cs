using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    /// <summary>
    /// 附近的打印机列表请求参数
    /// </summary>
    public class PrinterListByKeywordRequest : Merchant
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string lon { get; set; }
        /// <summary>
        /// 查询打印机的距离，单位公里
        /// </summary>
        public string distance { get; set; }

    }
}
