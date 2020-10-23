using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 快递公司表
    /// </summary>
    public class e_experssage
    {
        public int Eid{ get; set; }//快递主键编号
        public string EName { get; set; }//企业名称
        public string Ephone { get; set; }//客服电话
        public string Eofficial { get; set; }//官方网站
        public int Bid { get; set; }//判断是否开通
        public int Jid { get; set; }//是否开通
    }
}
