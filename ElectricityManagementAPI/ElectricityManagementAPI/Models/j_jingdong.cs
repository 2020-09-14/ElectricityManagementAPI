using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 申请京东表
    /// </summary>
    public class j_jingdong
    {
        public int Jid{ get; set; }
        public string Jmerchant { get; set; }
        public string Jidentification { get; set; }
        public int Jtype { get; set; }
        public int Jquantity { get; set; }
        public float Jfirstheavy { get; set; }
        public float Jcountined { get; set; }
        public DateTime Jtime { get; set; }
    }
}
