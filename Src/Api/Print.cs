using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Codeplex.Data;
using CsharpHttpHelper;
using PonyPrint.Model;
using PonyPrint.RequestModel;
using PonyPrint.Util;

namespace PonyPrint.Api
{
    /// <summary>
    /// 打印接口
    /// </summary>
    public class Print
    {
        /// <summary>
        /// 文件转换
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="srcUrl">文件可访问的 Url</param>
        /// <param name="md5">文件 MD5</param>
        /// <param name="clientParam">第三方自定义参数，要求唯一</param>
        /// <returns></returns>
        public static string TransferFile(string fileName, string srcUrl, string md5, string clientParam)
        {
            //请求信息
            var postMsg = new TransferRequest()
            {
                fileName = fileName,
                srcUrl = srcUrl,
                md5 = md5,
                clientParam = clientParam,
                notifyUrl = Config.TrabsferNotifyUrl
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/transferFile/transfer",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                PostEncoding = Encoding.UTF8
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {

                Log.DebugLogs("【文件转换】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【文件转换】请求参数", item.Postdata);
                Log.DebugLogs("【文件转换】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    return json.orderNo;
                }
                else
                {
                    Log.Error("TransferFile", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 文件转换
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="srcUrl">文件可访问的 Url</param>
        /// <param name="md5">文件 MD5</param>
        /// <param name="clientParam">第三方自定义参数，要求唯一</param>
        /// <param name="notifyUrl">文件转换异步通知地址</param>
        /// <returns></returns>
        public static string TransferFile(string fileName, string srcUrl, string md5, string clientParam,string notifyUrl)
        {
            //请求信息
            var postMsg = new TransferRequest()
            {
                fileName = fileName,
                srcUrl = srcUrl,
                md5 = md5,
                clientParam = clientParam,
                notifyUrl = notifyUrl
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/transferFile/transfer",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                PostEncoding = Encoding.UTF8
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {

                Log.DebugLogs("【文件转换】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【文件转换】请求参数", item.Postdata);
                Log.DebugLogs("【文件转换】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    return json.orderNo;
                }
                else
                {
                    Log.Error("TransferFile", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 添加打印任务
        /// </summary>
        /// <param name="orderNo">小马平台订单号</param>
        /// <param name="printStartPage">任务起始页码</param>
        /// <param name="printEndPage">任务结束页码</param>
        /// <param name="printerDevSn">打印机生产编码</param>
        /// <param name="printerCode">打印机二维码</param>
        /// <param name="copyCount">打印份数</param>
        /// <param name="duplexType">单双面</param>
        /// <returns></returns>
        public static PrintTask AddPrintTask(string orderNo, int printStartPage, int printEndPage, string printerDevSn, string printerCode, string copyCount, int duplexType)
        {
            //请求信息
            var postMsg = new PrintTaskRequest()
            {
                orderNo = orderNo,
                printStartPage = printStartPage,
                printEndPage = printEndPage,
                printerDevSn = printerDevSn,
                //printerCode = printerCode,
                notifyUrl = Config.PrintTaskNotifyUrl,
                copyCount = copyCount,
                duplexType = duplexType,
                strategyNo = 1
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printTask/addPrintTask",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【添加打印任务】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【添加打印任务】请求参数", item.Postdata);
                Log.DebugLogs("【添加打印任务】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var printTask = new PrintTask()
                    {
                        OrderNo = json.orderNo,
                        StartPage = json.startPage.ToString(),
                        EndPage = json.endPage.ToString(),
                        CopyCount = json.copyCount.ToString(),
                        ServiceStationId = json.serviceStationId.ToString(),
                        ServiceStationName = json.serviceStationName,
                        DuplexType = int.Parse(json.duplexType.ToString()),
                        StrategyNo = int.Parse(json.strategyNo.ToString()),
                        PrinterDevSn = json.printerDevSn,
                        PrintFee = double.Parse(json.printFee.ToString()),
                        PrintPaperCount = int.Parse(json.printPaperCount.ToString()),
                        OrderStatus = json.orderStatus.ToString()
                    };
                    return printTask;
                }
                else
                {
                    Log.Error("AddPrintTask", $"【Code】{json.respCode.ToString()}【Msg】{json.respMsg.ToString()}");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加打印任务
        /// </summary>
        /// <param name="orderNo">小马平台订单号</param>
        /// <param name="printStartPage">任务起始页码</param>
        /// <param name="printEndPage">任务结束页码</param>
        /// <param name="printerDevSn">打印机生产编码</param>
        /// <param name="printerCode">打印机二维码</param>
        /// <param name="copyCount">打印份数</param>
        /// <param name="duplexType">单双面</param>
        /// <param name="strategyNo">拼页设置</param>
        /// <param name="notifyUrl">文件打印异步通知地址</param>
        /// <returns></returns>
        public static PrintTask AddPrintTask(string orderNo, int printStartPage, int printEndPage, string printerDevSn, string printerCode, string copyCount, int duplexType,int strategyNo,string notifyUrl)
        {
            //请求信息
            var postMsg = new PrintTaskRequest()
            {
                orderNo = orderNo,
                printStartPage = printStartPage,
                printEndPage = printEndPage,
                printerDevSn = printerDevSn,
                //printerCode = printerCode,
                notifyUrl = notifyUrl,
                copyCount = copyCount,
                duplexType = duplexType,
                strategyNo = strategyNo
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printTask/addPrintTask",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【添加打印任务】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【添加打印任务】请求参数", item.Postdata);
                Log.DebugLogs("【添加打印任务】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var printTask = new PrintTask()
                    {
                        OrderNo = json.orderNo,
                        StartPage = json.startPage.ToString(),
                        EndPage = json.endPage.ToString(),
                        CopyCount = json.copyCount.ToString(),
                        ServiceStationId = json.serviceStationId.ToString(),
                        ServiceStationName = json.serviceStationName,
                        DuplexType = int.Parse(json.duplexType.ToString()),
                        StrategyNo = int.Parse(json.strategyNo.ToString()),
                        PrinterDevSn = json.printerDevSn,
                        PrintFee = double.Parse(json.printFee.ToString()),
                        PrintPaperCount = int.Parse(json.printPaperCount.ToString()),
                        OrderStatus = json.orderStatus.ToString()
                    };
                    return printTask;
                }
                else
                {
                    Log.Error("AddPrintTask", $"【Code】{json.respCode.ToString()}【Msg】{json.respMsg.ToString()}");
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
