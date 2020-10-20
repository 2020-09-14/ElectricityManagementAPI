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
        public async Task<IActionResult> GetOder(int states,
            string   ordernum  ,
             string  paytype   ,
              string buyerliu  ,
              string begintime ,
              string overtime  ,
              string goodsname ,
              string goodsnum  ,
              string buyername ,
              string tel       ,
            int page,
            int pageSize)
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
        [Route("/api/DelAll")]
        [HttpGet]
        public async Task<IActionResult> DelAll([FromQuery] string ids)
        {
            
            var del = await _electricityManagement.DelAllAsync(ids);
            return Ok(del);
        }
    }
}
