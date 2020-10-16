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
        public int Bid { get; set; }
        public string MBmerchant { get; set; }
        public string Bcheckout { get; set; }
        public string Btime { get; set; }
    }
}
