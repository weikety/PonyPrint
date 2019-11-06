using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.Model
{
    /// <summary>
    /// 打印任务
    /// </summary>
    public class PrintTask
    {
        /// <summary>
        /// 小马平台订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 任务起始页码 
        /// </summary>
        public string StartPage { get; set; }
        /// <summary>
        /// 任务结束页码
        /// </summary>
        public string EndPage { get; set; }
        /// <summary>
        /// 打印份数
        /// </summary>
        public string CopyCount { get; set; }
        /// <summary>
        /// 打印服务站 ID 
        /// </summary>
        public string ServiceStationId { get; set; }
        /// <summary>
        /// 打印服务站名称
        /// </summary>
        public string ServiceStationName { get; set; }
        /// <summary>
        /// 单双面  1 单面  2 双面
        /// </summary>
        public int DuplexType { get; set; }
        /// <summary>
        /// 拼接方式  1 单面单页  2 单面双页  3 单面4页  4 单面8页
        /// </summary>
        public int StrategyNo { get; set; }
        /// <summary>
        /// 打印机设备编号
        /// </summary>
        public string PrinterDevSn { get; set; }
        /// <summary>
        /// 打印费用，单位分 
        /// </summary>
        public double PrintFee { get; set; }
        /// <summary>
        /// 打印的纸张数 
        /// </summary>
        public int PrintPaperCount { get; set; }
        /// <summary>
        /// 订单状态  1 待支付  2 支付成功  3 支付失败  4 待打印  5 打印中  6 打印完成  7 卡纸  8 缺纸  9 缺墨  10 未知异常  11 取消订单  12 已退款
        /// </summary>
        public string OrderStatus { get; set; }

    }
}
