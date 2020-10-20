using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class OrderModel
    {
        //订单管理
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int OrderGoodsId { get; set; }
        public int OrderBuyerId { get; set; }
        public DateTime OrderTime { get; set; }
        public int Orderstate { get; set; }
        public int OrderPay { get; set; }

        //订单取消
        public int OrdeCancelId { get; set; }
        public string OrdeCancelCause { get; set; }
        public string OrdeCancelInfo { get; set; }

        //商品
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImg { get; set; }
        public string GoodsIntroduce { get; set; }
        public int GoodsNum { get; set; }
        public float GoodsPrice { get; set; }

        //买家信息
        public int BuyerInfoId { get; set; }
        public string BuyerInfoName { get; set; }
        public string BuyerInfoTel { get; set; }
        public string BuyerInfoMess { get; set; }
        public int BuyerInfoPlace { get; set; }

        //买家地址表
        public int BuyerAddressId { get; set; }
        public string BuyerAddressName { get; set; }
        public string BuyerAddressInfo { get; set; }
        public string BuyerAddressTel { get; set; }
        //快递表
        public int Eid { get; set; }
        public string EName { get; set; }
        public string Ephone { get; set; }
        public string Eofficial { get; set; }
     
    }
}
