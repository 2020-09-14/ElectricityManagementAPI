using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    //商品分类表
    public class Classify
    {
        public int ClassifyId { get; set; }//主键
        public string Cname { get; set; }//分类名称
        public string coding { get; set; }//分类编号
        public int Cidd { get; set; }//上级分类{联动Id}
        public int SIdd { get; set; }//选择规格
        public bool State { get; set; }//状态{删除}
        public DateTime CreaTime { get; set; }//创建时间
    }
}
