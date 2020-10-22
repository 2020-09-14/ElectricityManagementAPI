using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    //商品
    public class Commodity
    {
        public int CommodityId { get; set; }//主键
        public string Recommend { get; set; }//商品推荐
        public int Bidd { get; set; }//商品属性【品牌外键】
        public string Pay { get; set; }//支付方式【线上，线下】
        public string Img { get; set; }//图片
        public string Introduce { get; set; }//规格
        public string Inventory { get; set; }//库存
        public int Cidd { get; set; }//分类外键
        public DateTime CreaTime { get; set; }//创建时间
        public string SCname { get; set; }//商品名称
        public int State { get; set; }//状态（删除）
        public int Price { get; set; }//售价
        public DateTime datetime  { get; set; }//放入垃圾桶时间{根据状态决定}
        public bool delstate { get; set; }//删除状态
        public string Cname { get; set; }
        public string Bname { get; set; }


        
        
    }
}
