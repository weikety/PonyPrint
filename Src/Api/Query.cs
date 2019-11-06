using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;
using CsharpHttpHelper;
using PonyPrint.Model;
using PonyPrint.RequestModel;
using PonyPrint.Util;

namespace PonyPrint.Api
{
    /// <summary>
    /// 查询接口
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 根据关键词 、经纬度、距离去查询范围内的打印机列表
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="log">经度</param>
        /// <param name="distance">距离(公里)</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public static List<Printer> GetPrinterListByKeyword(string lat, string log, string distance, string keyword)
        {
            //请求信息
            var postMsg = new PrinterListByKeywordRequest()
            {
                lon = log,
                lat = lat,
                distance = distance,
                keyword = keyword
            };

            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrinterListByKeyword",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【根据关键词 、经纬度、距离去查询范围内的打印机列表】请求响应】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【根据关键词 、经纬度、距离去查询范围内的打印机列表】请求响应】请求参数", item.Postdata);
                Log.DebugLogs("【根据关键词 、经纬度、距离去查询范围内的打印机列表】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var printerList = new List<Printer>();
                    foreach (var model in json.list)
                    {
                        printerList.Add(new Printer()
                        {
                            Id = model.id() ? (long)model.id : 0,
                            PrinterCode = model.printerCode() ? model.printerCode.ToString() : "",
                            PrinterName = model.printerName() ? model.printerName.ToString() : "",
                            PrinterType = model.printerType() ? model.printerType.ToString() : "",
                            ScanMode = model.scanMode() ? (int)model.scanMode : 0,
                            PrinterDevSn = model.printerDevSn() ? model.printerDevSn.ToString() : "",
                            PrinterStatus = model.printerStatus() ? (int)model.printerStatus : 0,
                            Longitude = model.longitude() ? model.longitude.ToString() : "",
                            Latitude = model.latitude() ? model.latitude.ToString() : "",
                            Distance = model.distance() ? model.distance.ToString() : "",
                            ServiceStationId = model.serviceStationId() ? (long)model.serviceStationId : 0,
                            ServiceStationName = model.serviceStationName() ? model.serviceStationName.ToString() : "",
                            ServiceStationAddress = model.serviceStationAddress() ? model.serviceStationAddress.ToString() : "",
                            ServiceStationPicUrl = model.serviceStationPicUrl() ? model.serviceStationPicUrl.ToString() : "",
                            ServiceStationPhone = model.serviceStationPhone() ? model.serviceStationPhone.ToString() : "",
                            ServiceStationDesc = model.serviceStationDesc() ? model.serviceStationDesc.ToString() : "",
                            BusinessStatus = model.businessStatus() ? (int)model.businessStatus : 0,
                            ServiceStationStatus = model.serviceStationStatus() ? (int)model.serviceStationStatus : 0,
                        });
                    }
                    return printerList;
                }
                else
                {
                    Log.Error("GetPrinterListByKeyword", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询打印机的打印单价和打印的纸张数
        /// </summary>
        /// <param name="serviceStationId">打印点的 id</param>
        /// <param name="printStartPage">打印开始的页码</param>
        /// <param name="printEndPage">打印结束的页码</param>
        /// <param name="copyCount">打印的份数</param>
        /// <param name="duplexType">单双面：1，单面；2，双面</param>
        /// <returns></returns>
        public static PrintPice GetPrintPriceInfo(long serviceStationId, string printStartPage, string printEndPage, string copyCount, string duplexType)
        {
            //请求信息
            var postMsg = new PrintPriceInfoRequest()
            {
                serviceStationId = serviceStationId,
                printStartPage = printStartPage,
                printEndPage = printEndPage,
                copyCount = copyCount,
                duplexType = duplexType,
                strategyNo = "1"
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrintPriceInfo",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【查询打印机的打印单价和打印的纸张数】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【查询打印机的打印单价和打印的纸张数】请求参数", item.Postdata);
                Log.DebugLogs("【查询打印机的打印单价和打印的纸张数】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var price = new PrintPice()
                    {
                        PrintPrice = (double)json.printPrice,
                        PrintPaperCount = (int)json.printPaperCount,
                        PrintFee = (double)json.printFee
                    };
                    return price;
                }
                else
                {
                    Log.Error("getPrintPriceInfo", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询打印机的打印单价和打印的纸张数
        /// </summary>
        /// <param name="serviceStationId">打印点的 id</param>
        /// <param name="printStartPage">打印开始的页码</param>
        /// <param name="printEndPage">打印结束的页码</param>
        /// <param name="copyCount">打印的份数</param>
        /// <param name="duplexType">单双面：1，单面；2，双面</param>
        /// <param name="strategyNo">拼页（1-1,2-2,3-4,4-8）</param>
        /// <returns></returns>
        public static PrintPice GetPrintPriceInfo(long serviceStationId, string printStartPage, string printEndPage, string copyCount, string duplexType,string strategyNo)
        {
            //请求信息
            var postMsg = new PrintPriceInfoRequest()
            {
                serviceStationId = serviceStationId,
                printStartPage = printStartPage,
                printEndPage = printEndPage,
                copyCount = copyCount,
                duplexType = duplexType,
                strategyNo = strategyNo
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrintPriceInfo",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【查询打印机的打印单价和打印的纸张数】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【查询打印机的打印单价和打印的纸张数】请求参数", item.Postdata);
                Log.DebugLogs("【查询打印机的打印单价和打印的纸张数】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var price = new PrintPice()
                    {
                        PrintPrice = (double)json.printPrice,
                        PrintPaperCount = (int)json.printPaperCount,
                        PrintFee = (double)json.printFee
                    };
                    return price;
                }
                else
                {
                    Log.Error("getPrintPriceInfo", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="orderNo">小马平台订单号</param>
        /// <returns></returns>
        public static OrderInfo GetOrderStatus(string orderNo)
        {
            //请求信息
            var postMsg = new OrderStatusRequest()
            {
                orderNo = orderNo
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printOrder/getOrderStatus",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【根据订单号查询】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【根据订单号查询】请求参数", item.Postdata);
                Log.DebugLogs("【根据订单号查询】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var orderInfo = new OrderInfo()
                    {
                        OrderStatus = json.orderStatus.ToString(),
                        ErrorDetail = json.errorDetail.ToString(),
                        OrderNo = json.orderNo.ToString(),
                        SuccessPaperCount = (int)json.successPaperCount,
                        PrintFee = (int)json.printFee,
                        RefundFee = (int)json.refundFee,
                        TransferStatus = (int)json.transferStatus
                    };
                    return orderInfo;
                }
                else
                {
                    Log.Error("GetOrderStatus", json.respMsg.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据SN编号获取打印机状态
        /// </summary>
        /// <param name="printerSn">打印机编号</param>
        /// <returns></returns>
        public static PrinterState GetPrintStatus(string printerSn)
        {
            //请求信息
            var postMsg = new PrinterInfoByPrinterDevSnOrCode()
            {
                printerDevSn = printerSn,
                printerCode = ""
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrinterInfoByPrinterDevSnOrCode",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【根据SN编号获取打印机状态】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【根据SN编号获取打印机状态】请求参数", item.Postdata);
                Log.DebugLogs("【根据SN编号获取打印机状态】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    if (json.printerStatus())
                    {
                        try
                        {
                            var state = (int)json.printerStatus;
                            switch (state)
                            {
                                case 0:
                                case 1:
                                    return new PrinterState() { Status = 1, Msg = "空闲" };
                                case 2:
                                    return new PrinterState() { Status = 2, Msg = "任务繁忙" };
                                default:
                                    return new PrinterState() { Status = 3, Msg = "维护中" };
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error("GetPrint", e.ToString());
                            return new PrinterState() { Status = 3, Msg = "维护中" };
                        }

                    }
                    else
                    {
                        return new PrinterState() { Status = 3, Msg = "维护中" };
                    }
                }
                else
                {
                    Log.Error("GetPrint", json.respMsg.ToString());
                    return new PrinterState() { Status = 3, Msg = "维护中" };
                }
            }
            else
            {
                return new PrinterState() { Status = 3, Msg = "维护中" };
            }
        }

        /// <summary>
        /// 根据SN编号获取打印机是否支持扫描
        /// </summary>
        /// <param name="printerSn">打印机编号</param>
        /// <returns></returns>
        public static PrintScanModel GetPrintScanModel(string printerSn)
        {
            //请求信息
            var postMsg = new PrinterInfoByPrinterDevSnOrCode()
            {
                printerDevSn = printerSn,
                printerCode = ""
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrinterInfoByPrinterDevSnOrCode",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【根据SN编号获取打印机是否支持扫描】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【根据SN编号获取打印机是否支持扫描】请求参数", item.Postdata);
                Log.DebugLogs("【根据SN编号获取打印机是否支持扫描】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    if (json.printerDevSn() && json.scanMode())
                    {
                        try
                        {
                            var state = (int)json.scanMode;
                            switch (state)
                            {
                                case 1:
                                    return new PrintScanModel() { Status = 1, Msg = "该打印机支持扫描" };
                                case 2:
                                    return new PrintScanModel() { Status = 2, Msg = "打印机不支持扫描" };
                                default:
                                    return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error("GetPrintScanModel", e.ToString());
                            return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                        }
                    }
                    else
                    {
                        return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                    }
                }
                else
                {
                    Log.Error("GetPrint", json.respMsg.ToString());
                    return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                }
            }
            else
            {
                return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
            }
        }

        /// <summary>
        /// 根据二维码获取打印机是否支持扫描
        /// </summary>
        /// <param name="printerCode">打印机编号</param>
        /// <returns></returns>
        public static PrintScanModel GetPrintScanModelByprinterCode(string printerCode)
        {
            //请求信息
            var postMsg = new PrinterInfoByPrinterDevSnOrCode()
            {
                printerDevSn = "",
                printerCode = printerCode
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrinterInfoByPrinterDevSnOrCode",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【根据SN编号获取打印机是否支持扫描】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【根据SN编号获取打印机是否支持扫描】请求参数", item.Postdata);
                Log.DebugLogs("【根据SN编号获取打印机是否支持扫描】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    if (json.printerDevSn() && json.scanMode())
                    {
                        try
                        {
                            var state = (int)json.scanMode;
                            switch (state)
                            {
                                case 1:
                                    return new PrintScanModel() { Status = 1, Msg = "该打印机支持扫描" };
                                case 2:
                                    return new PrintScanModel() { Status = 2, Msg = "打印机不支持扫描" };
                                default:
                                    return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error("GetPrintScanModel", e.ToString());
                            return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                        }
                    }
                    else
                    {
                        return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                    }
                }
                else
                {
                    Log.Error("GetPrint", json.respMsg.ToString());
                    return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
                }
            }
            else
            {
                return new PrintScanModel() { Status = 0, Msg = "扫码错误" };
            }
        }

        /// <summary>
        /// 根据SN编号获取打印机信息
        /// </summary>
        /// <param name="printerSn">打印机生产编号</param>
        /// <param name="printerCode">打印机二维码</param>
        /// <returns></returns>
        public static Printer GetPrintInfo(string printerSn,string printerCode)
        {
            //请求信息
            var postMsg = new PrinterInfoByPrinterDevSnOrCode()
            {
                printerDevSn = printerSn,
                printerCode = printerCode
            };
            var http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = $"{Config.ApiUrl}/atiot-open/api/printerInfo/getPrinterInfoByPrinterDevSnOrCode",
                Method = "post",
                Encoding = Encoding.UTF8,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Tool.GetAsciiSortMd5Post(postMsg),
                Expect100Continue = false
            };
            var result = http.GetHtml(item);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Log.DebugLogs("【根据SN编号获取打印机信息】请求对象", DynamicJson.Serialize(postMsg));
                Log.DebugLogs("【根据SN编号获取打印机信息】请求参数", item.Postdata);
                Log.DebugLogs("【根据SN编号获取打印机信息】请求响应", DynamicJson.Serialize(result));

                var json = DynamicJson.Parse(result.Html.Trim());
                if (json.respCode() && json.respCode == 1000)
                {
                    var model = new Printer()
                    {
                        Id = long.Parse(json.id.ToString()),
                        Latitude = json.latitude,
                        Longitude = json.longitude,
                        PrinterDevSn = json.printerDevSn,
                        PrinterName = json.printerName,
                        PrinterStatus = int.Parse(json.printerStatus.ToString()),
                        PrinterType = json.printerType,
                        ScanMode = int.Parse(json.scanMode.ToString()),
                        ServiceStationId = long.Parse(json.serviceStationId.ToString()),
                        ServiceStationName = json.serviceStationName
                    };
                    return model;
                }
                else
                {
                    Log.Error("GetPrint", json.respMsg.ToString());
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
