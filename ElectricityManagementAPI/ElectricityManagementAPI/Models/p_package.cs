using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 包裹中心
    /// </summary>
    public class p_package
    {
        public int Pid { get; set; }//主键id
        public int Eid { get; set; }//外键id
        public string Podd { get; set; }//快递单号
        public DateTime Ptime { get; set; }//发货时间
        public int Pordernumber { get; set; }//订单号
        public string Pstate { get; set; }//包裹状态
        public string Panomaly { get; set; }//异常状态
        public DateTime Panomalytime { get; set; }//异常时长
        public bool PapprovalStatus { get; set; }//审批状态
        public bool Pstatus { get; set; }
        public string Pdescribe { get; set; }//问题描述
        public string EName { get; set; }
        public string OrderNumber { get; set; }
    }
}
