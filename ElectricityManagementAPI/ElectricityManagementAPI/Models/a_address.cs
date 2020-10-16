using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 地址表
    /// </summary>
    public class a_address
    {
        public int Aid { get; set; }
        public string Abbreviation { get; set; }
        public string Aconsigner { get; set; }
        public string Aphone { get; set; }
        public int Address { get; set; }
        public string Adeltailedaddress { get; set; }
        public bool Adeliverypoint { get; set; }
        public bool Areceivingpoint { get; set; }
        public DateTime Atime { get; set; }
        public bool Astate { get; set; }
    }
}
