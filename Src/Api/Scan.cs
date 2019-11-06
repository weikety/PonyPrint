using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;
using CsharpHttpHelper;
using PonyPrint.RequestModel;
using PonyPrint.Util;

namespace PonyPrint.Api
{
    public class Scan
    {
        /// <summary>
        /// 扫描任务
        /// </summary>
        /// <param name="scanType">扫描类型， 2 单页扫描,3 连续扫描 6 身份证扫描</param>
        /// <param name="printerDevSn">打印机编号 SN</param>
        /// <param name="thirdScanNo">第三方商户的扫描编号</param>
        /// <param name="notifyUrl">文件扫描异步通知地址</param>
        /// <returns>返回扫描编号</returns>
        public static string ScanFile(string scanType, string printerDevSn, string thirdScanNo, string notifyUrl)
        {
            //请求信息
            var postMsg = new ScanRequest()
            {
                scanType = scanType,
                printerDevSn = printerDevSn,
                thirdScanNo = thirdScanNo,
                scanNotifyUrl = notifyUrl
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/scan/scanFile",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                PostEncoding = Encoding.UTF8
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {

                Log.DebugLogs("【扫描任务】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【扫描任务】请求参数", item.Postdata);
                Log.DebugLogs("【扫描任务】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    return json.scanId.ToString();
                }
                else
                {
                    Log.Error("ScanFile", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
