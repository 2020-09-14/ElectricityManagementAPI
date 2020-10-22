using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    //商品评价
    public class Evaluate
    {
        public int Evaluateid { get; set; }//主键
        public string stars { get; set; }//五星评论
        public string Content { get; set; }//评论内容
        public DateTime Creatime { get; set; }//评论时间
        public int Uidd { get; set; }//用户外键
        public bool state { get; set; }//状态
        public int Cidd { get; set; }//商品外键

        //用户BuyerInfoModel
        public string BuyerInfoName { get; set; }//用户名
        public string BuyerInfoTel { get; set; }//电话
        //商品Commodity
        public string SCname { get; set; }//商品名称
        public string Img { get; set; }//商品图片
        public string Introduce { get; set; }//规格//商品规格
        public int CommodityId { get; set; }//主键
    }
}
