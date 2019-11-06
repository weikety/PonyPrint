using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.RequestModel
{
    public class PrinterInfoByPrinterDevSnOrCode : Merchant
    {
        /// <summary>
        /// 打印机生产编号
        /// </summary>
        public string printerDevSn { get; set; }
        /// <summary>
        /// 打印机二维码
        /// </summary>
        public string printerCode { get; set; }
    }
}
