using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.Model
{
    /// <summary>
    /// 打印机
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// 打印机 ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 打印机编号
        /// </summary>
        public string PrinterCode { get; set; }      
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrinterName { get; set; }
        /// <summary>
        /// 打印机类型  unknow(“0”,”未知型号”,null),ES(“ES”,”黑白激光打印机”,null),EM(“EM”,”黑白激光一体机”,null),EC(“EC”,”彩色照片打印机”,null)
        /// </summary>
        public string PrinterType { get; set; }
        /// <summary>
        /// 扫描模式,1 支持扫描,2 不支持扫描
        /// </summary>
        public int ScanMode { get; set; }
        /// <summary>
        /// 打印机设备编号
        /// </summary>
        public string PrinterDevSn { get; set; }
        /// <summary>
        /// 打印机状态 1 空闲 2 任务繁忙  3 维护中
        /// </summary>
        public int PrinterStatus { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 距离
        /// </summary>
        public string Distance { get; set; }
        /// <summary>
        /// 服务站 ID 
        /// </summary>
        public long ServiceStationId { get; set; }
        /// <summary>
        /// 打印服务站名称
        /// </summary>
        public string ServiceStationName { get; set; }
        /// <summary>
        /// 打印服务站地址
        /// </summary>
        public string ServiceStationAddress { get; set; }
        /// <summary>
        /// 打印服务站近景照
        /// </summary>
        public string ServiceStationPicUrl { get; set; }
        /// <summary>
        /// 打印服务站联系方式
        /// </summary>
        public string ServiceStationPhone { get; set; }
        /// <summary>
        /// 打印服务站简介
        /// </summary>
        public string ServiceStationDesc { get; set; }
        /// <summary>
        /// 商业模式，1 商用，2 自用
        /// </summary>
        public int BusinessStatus { get; set; }
        /// <summary>
        /// 营业状态，1 营业，2 下线
        /// </summary>
        public int ServiceStationStatus { get; set; }

    }
}
