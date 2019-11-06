using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    /// <summary>
    /// 被继承 商户号
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string merchantCode { get; set; } = Config.MerchanCode;
    }
}
