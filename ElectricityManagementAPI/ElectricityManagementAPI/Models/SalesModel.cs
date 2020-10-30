using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class SalesModel
    {
        //退货列表
        public int SalesId { get; set; }

       
        //运单
        public int WayBillId { get; set; }
        public string WayBillNumber { get; set; }
        public DateTime WayBillTime { get; set; }
        public int WayBillOrderId { get; set; }
        public int WayBillState { get; set; }
        public string WayBillExpress { get; set; }
        //退换货原因
        public int SalesExchangeId { get; set; }

        public string SalesNumber { get; set; }//退货单号
        public DateTime SalesTime { get; set; }//申请时间
        public int ReturnSalesId { get; set; }//退货原因
        public int SalesState { get; set; }//退货状态
        public int SalesOrderId { get; set; }//订单外键
        //退换货原因
      


        public string SalesExchangeCause { get; set; }
        public string SalesExchangeInfo { get; set; }

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
     

        //快递公司
        public int Eid { get; set; }//快递主键编号
        public string EName { get; set; }//企业名称
        public string Ephone { get; set; }//客服电话
        public string Eofficial { get; set; }//官方网站
        public int Bid { get; set; }//判断是否开通
        public int Jid { get; set; }//是否开通

    }
}
