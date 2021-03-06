﻿using ElectricityManagementAPI.Dal;
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
        public async Task<IActionResult> GetSales(string SalesNumber,string OrderNumber,string BuyerAddressTel,string BuyerAddressName, string begintime, string overtime, string EName,int page,int pageSize) 
        {
            List<SalesModel> GetOrders = await _electricityManagement.GetSales();

            if (!string.IsNullOrEmpty(SalesNumber))
            {
                GetOrders = GetOrders.Where(t=>t.SalesNumber.Contains(SalesNumber)).ToList();
            }
            //订单号查询
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                GetOrders = GetOrders.Where(t=>t.OrderNumber.Contains(OrderNumber)).ToList();
            }

            if (!string.IsNullOrEmpty(BuyerAddressTel))
            {
                GetOrders = GetOrders.Where(t => t.BuyerInfoTel.Contains(BuyerAddressTel)).ToList();
            }
            
            if (!string.IsNullOrEmpty(BuyerAddressName))
            {
                GetOrders = GetOrders.Where(t => t.BuyerInfoName.Contains(BuyerAddressName)).ToList();
            }
            
            if (!string.IsNullOrEmpty(begintime) || !string.IsNullOrEmpty(overtime))
            {

                GetOrders = GetOrders.Where(t => t.SalesTime > Convert.ToDateTime(begintime) && t.SalesTime < Convert.ToDateTime(overtime)).ToList();
            }
            //商品名称
            if (!string.IsNullOrEmpty(EName))
            {
                GetOrders = GetOrders.Where(t =>t.EName.Contains(EName)).ToList();
            }
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
    }
}
