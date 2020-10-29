using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Tissue
    {
        //组织表
        public int TId { get; set; }
        public string TName { get; set; }//组织名称
        public string TLinkman { get; set; }//联系人
        public string TPhone { get; set; }//手机号
        public DateTime TTime { get; set; }//更新时间
        public int TState { get; set; }//当前状态
    }
}
