using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 申请网点表
    /// </summary>
    public class b_branch
    {
        public int Bid { get; set; }//主键编号
        public string MBmerchant { get; set; }//商家编号
        public string Bcheckout { get; set; }//检验字段
        public string Btime { get; set; }//时间
    }
}
