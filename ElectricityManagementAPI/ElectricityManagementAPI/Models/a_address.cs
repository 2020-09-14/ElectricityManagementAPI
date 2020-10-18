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
        public int Aid { get; set; }//地址主键id
        public string Abbreviation { get; set; }//地址简称
        public string Aconsigner { get; set; }//收货人
        public string Aphone { get; set; }//手机号
        public string Address { get; set; }//地址
        public string Adeltailedaddress { get; set; }//详细地址
        public bool Adeliverypoint { get; set; }//设为发货人
        public bool Areceivingpoint { get; set; }//设为受害人
        public DateTime Atime { get; set; }//时间
        public bool Astate { get; set; }//状态
    }
}
