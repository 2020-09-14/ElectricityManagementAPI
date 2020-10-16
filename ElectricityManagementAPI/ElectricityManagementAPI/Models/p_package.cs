using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 包裹中心表
    /// </summary>
    public class p_package
    {
        public int Pid{ get; set; }
        public int Eid { get; set; }
        public string PName { get; set; }
        public string Phone { get; set; }
        public string Podd { get; set; }
        public DateTime Ptime { get; set; }
        public string Pordernumber { get; set; }
        public bool Pstate { get; set; }
        public string Panomaly { get; set; }
        public string Panomalytime { get; set; }
        public bool PapprovalStatus { get; set; }
        public string Pdispose { get; set; }
    }
}
