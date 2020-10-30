using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Helper;
using ElectricityManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IElectricityManagement _electricityManagement;
        public OrderController(IElectricityManagement electricityManagement)
        {
            _electricityManagement = electricityManagement;
        }
        [HttpGet]

        [Route("/api/Order")]
 

        public async Task<IActionResult> GetOder(int states, string   ordernum  ,string  paytype   ,string buyerliu  ,string begintime ,string overtime  , string goodsname , string goodsnum  ,string buyername ,string tel,int page,int pageSize)

        {
            List<OrderModel> GetOrders = await _electricityManagement.GetOrdersAsync(states);
            if (!string.IsNullOrEmpty(ordernum))
            {
                GetOrders = GetOrders.Where(t => t.OrderNumber.Contains(ordernum)).ToList();
            }//订单号查询
            if (!string.IsNullOrEmpty(paytype))
            {
                GetOrders = GetOrders.Where(t => t.OrderPay==Convert.ToInt32(paytype)).ToList();
            }//支付类型         1 支付宝   2微信
            if (!string.IsNullOrEmpty(buyerliu))
            {
                GetOrders = GetOrders.Where(t => t.BuyerInfoMess.Contains(buyerliu)).ToList();
            }//用户留言
            if (!string.IsNullOrEmpty(begintime) || !string.IsNullOrEmpty(overtime))
            {
           
                GetOrders = GetOrders.Where(t => t.OrderTime>Convert.ToDateTime(begintime)&&t.OrderTime<Convert.ToDateTime(overtime)).ToList();
            }//时间查询
            if (!string.IsNullOrEmpty(goodsname))
            {
                GetOrders = GetOrders.Where(t => t.GoodsName.Contains(goodsname)).ToList();
            }//商品名称
            if (!string.IsNullOrEmpty(goodsnum))
            {
                GetOrders = GetOrders.Where(t => t.GoodsNum==Convert.ToInt32(goodsnum)).ToList();
            }//商品编码
            if (!string.IsNullOrEmpty(buyername))
            {
                GetOrders = GetOrders.Where(t => t.BuyerInfoName.Contains(buyername)).ToList();
            }//用户昵称
            if (!string.IsNullOrEmpty(tel))
            {
                GetOrders = GetOrders.Where(t => t.BuyerInfoTel==(tel)).ToList();
            }//用户电话
            var count = GetOrders.Count;
            GetOrders = GetOrders.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var model = new
            {
                counts = count,
                lists = GetOrders
            };
            return Ok(model);
        }
        [Route("/api/GetOrdersDeliver")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersDeliver()
        {
            var GetDelivers = await _electricityManagement.GetOrdersDeliverAsync();
            return Ok(GetDelivers);
        }
        [Route("/api/GetOderDetil")]
        [HttpGet]
        public async Task<IActionResult> GetOderDetil(int ids)
        {
            List<OrderModel> GetOrders = await _electricityManagement.GetOrdersDetialAsync(ids);
            return Ok(GetOrders);
        }
        [Route("/api/DelAll")]
        [HttpGet]
        public async Task<IActionResult> DelAll([FromQuery] string ids)
        {
            
            var del = await _electricityManagement.DelAllAsync(ids);
            return Ok(del);
        }
        //批量发货
        [Route("/api/GetVf")]
        [HttpGet]
        public async Task<IActionResult> GetVAsync([FromQuery]string WayBiilNumber, [FromQuery] string WayBillOrderId , [FromQuery] string WayBillExpress)
        {
            return Ok(await _electricityManagement.GetVAsync(WayBiilNumber, WayBillOrderId, WayBillExpress));
        }

        //退货列表
        [HttpGet]
        [Route("/api/GetSales")]
        public async Task<IActionResult> GetSales(int states, string salesnum, string expressnum, string telnum, string begintime, string overtime, string express, string salesname,
         string salesex,
       int page,
       int pageSize) 
        {
            List<SalesModel> GetOrders = await _electricityManagement.GetSales(states);

            if (!string.IsNullOrEmpty(salesnum))
            {
                GetOrders = GetOrders.Where(t => t.SalesNumber == salesnum).ToList();
            }//换货单号
            if (!string.IsNullOrEmpty(expressnum))
            {
                GetOrders = GetOrders.Where(t => t.WayBillNumber == expressnum).ToList();
            }//快递单号         1 支付宝   2微信

            if (!string.IsNullOrEmpty(telnum))
            {
                GetOrders = GetOrders.Where(t => t.BuyerAddressTel == telnum).ToList();
            }//退货人手机
            if (!string.IsNullOrEmpty(salesname))
            {
                GetOrders = GetOrders.Where(t => t.BuyerAddressName.Contains(salesname)).ToList();
            }//退货人昵称
            if (!string.IsNullOrEmpty(begintime) || !string.IsNullOrEmpty(overtime))
            {

                GetOrders = GetOrders.Where(t => t.SalesTime > Convert.ToDateTime(begintime) && t.SalesTime < Convert.ToDateTime(overtime)).ToList();
            }//时间查询
            if (!string.IsNullOrEmpty(express))
            {
                GetOrders = GetOrders.Where(t => t.WayBillExpress == (express)).ToList();
            }//快递公司
            if (!string.IsNullOrEmpty(salesex))
            {
                GetOrders = GetOrders.Where(t => t.ReturnSalesId == Convert.ToInt32(salesex)).ToList();
            }//退换货原因

            var count = GetOrders.Count;
            GetOrders = GetOrders.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var model = new
            {
                counts = count,
                lists = GetOrders
            };
            return Ok(model);
        }
        //显示退货申请-待审核
        [HttpGet]
        [Route("/api/DetailsSales")]
        public async Task<IActionResult> DetailsSales(int id) 
        {
            List<SalesModel> list = (await _electricityManagement.DetailsSales(id));
            return Ok(list);
        }
        [HttpGet]
        [Route("/api/salaschange")]
        public async Task<IActionResult> SaleschangeXiala()
        {
            var list = await _electricityManagement.GetSalesExchangesAsync();
            return Ok(list);
        }
    } 
}
