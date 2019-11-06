using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PonyPrint
{
    public class Config
    {
        /// <summary>
        /// 访问服务器地址
        /// </summary>
        public static string ApiUrl = ConfigurationManager.AppSettings["PPApiUrl"];
        /// <summary>
        /// 商户号
        /// </summary>
        public static string MerchanCode = ConfigurationManager.AppSettings["PPMerchanCode"];
        /// <summary>
        /// 加密秘钥
        /// </summary>
        public static string AppSecret = ConfigurationManager.AppSettings["PPAppSecret"];
        /// <summary>
        /// 文件转换异步通知地址
        /// </summary>
        public static string TrabsferNotifyUrl = ConfigurationManager.AppSettings["PPTrabsferNotifyUrl"];
        /// <summary>
        /// 打印任务异步通知地址
        /// </summary>
        public static string PrintTaskNotifyUrl = ConfigurationManager.AppSettings["PPPrintTaskNotifyUrl"];
        /// <summary>
        /// 是否调试模式
        /// </summary>
        public static string Debug = ConfigurationManager.AppSettings["PPDebug"];

    }
}
