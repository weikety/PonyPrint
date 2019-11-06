using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.Model
{
    public class OrderInfo
    {
        /// <summary>
        /// 订单状态  1 待支付  2 支付成功  3 支付失败  4 待打印  5 打印中  6 打印完成  7 卡纸  8 缺纸  9 缺墨  10 未知异常  11 取消订单  12 已退款  
        /// </summary>
        public string OrderStatus { get; set; }
        /// <summary>
        /// 打印机错误详情  QM：日本打印机缺墨，TWQM： 台湾打印机缺墨，QZ：日本打印机缺纸，TWQZ：台湾打印机缺纸，QGKZ：前盖卡纸，GZHKZ：供纸盒卡纸，HGKZ：后盖卡纸，TWQGKZ：台湾打印机前盖卡纸，TWGZHKZ：台湾打印机供纸盒卡纸，TWHGKZ：台湾后纸盒卡纸，TWSMDYKZ：台湾双面打印单元卡纸
        /// </summary>
        public string ErrorDetail { get; set; }
        /// <summary>
        /// 小马平台订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 打印成功的总张数
        /// </summary>
        public int SuccessPaperCount { get; set; }
        /// <summary>
        /// 商户打印费用，单位分
        /// </summary>
        public int PrintFee { get; set; }
        /// <summary>
        /// 商户退款费用，单位分
        /// </summary>
        public int RefundFee { get; set; }
        /// <summary>
        /// 文件转换状态
        /// </summary>
        public int TransferStatus { get; set; }
        /// <summary>
        /// 返回码   1000 正常   2000 服务异常   2014 打印订单获取异常   2015 支付异常
        /// </summary>
        public int RespCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string RespMsg { get; set; }
        
    }
}
