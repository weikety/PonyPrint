using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    /// <summary>
    /// 订单查询请求参数
    /// </summary>
    public class OrderStatusRequest : Merchant
    {
        /// <summary>
        /// 小马平台订单号
        /// </summary>
        public string orderNo { get; set; }

    }
}
