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
        public int Jid{ get; set; }//申请京东Id
        public string Jmerchant { get; set; }//商家编码
        public string Jidentification { get; set; }//账号表示
        public int Jtype { get; set; }//运费类型
        public int Jquantity { get; set; }//月考核量
        public float Jfirstheavy { get; set; }//首重价格
        public float Jcountined { get; set; }//续重价格
        public DateTime Jtime { get; set; }//时间
    }
}
