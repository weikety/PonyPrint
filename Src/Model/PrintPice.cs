using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyPrint.Model
{
    public class PrintPice
    {
        /// <summary>
        /// 打印单价，单位分
        /// </summary>
        public double PrintPrice { get; set; }
        /// <summary>
        /// 打印张数
        /// </summary>
        public int PrintPaperCount { get; set; }
        /// <summary>
        /// 打印总费用，单位分
        /// </summary>
        public double PrintFee { get; set; }

    }
}
