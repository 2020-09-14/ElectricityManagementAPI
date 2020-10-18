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
        public int Pid{ get; set; }//包裹中心id
        public int Eid { get; set; }//快递公司id
        public string PName { get; set; }//收货人姓名
        public string Phone { get; set; }//手机号
        public string Podd { get; set; }//快递单号
        public DateTime Ptime { get; set; }//发货时间
        public string Pordernumber { get; set; }//订单号
        public bool Pstate { get; set; }//包裹状态
        public string Panomaly { get; set; }//异常状态
        public string Panomalytime { get; set; }//异常时长
        public bool PapprovalStatus { get; set; }//审批状态
        public string Pdispose { get; set; }//处理状态
    }
}
