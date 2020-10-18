using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 运费模板表
    /// </summary>
    public class f_freight
    {
        public int Fid { get; set; }//运费模板id
        public string FName{ get; set; }//模板名称
        public int Fregin { get; set; }//发货地区
        public bool Fcarriage { get; set; }//运费设置
        public bool Fvaluation { get; set; }//计价方式
        public int Fpice { get; set; }//默认件/kg
        public float Felement { get; set; }//默认钱
        public int Fletter { get; set; }//增加件/kg
        public float Funit { get; set; }//增加钱
        public DateTime Fdatetiem { get; set; }//时间
        public bool Fstate { get; set; }//状态
        public bool Fcondition { get; set; }//默认地址
    }
}
