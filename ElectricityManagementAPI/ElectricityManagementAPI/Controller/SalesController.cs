using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private IElectricityManagement _electricityManagement;
        public SalesController(IElectricityManagement electricityManagement)
        {
            _electricityManagement = electricityManagement;
        }

        [HttpGet]
        public async Task<IActionResult> GetOder(int states, string salesnum, string expressnum, string telnum, string begintime, string overtime, string express, string salesname,
         string salesex,
         
       int page,
       int pageSize)
        {
            List<SalesModel> GetOrders = await _electricityManagement.GetSales(states);
            if (!string.IsNullOrEmpty(salesnum))
            {
                GetOrders = GetOrders.Where(t => t.SalesNumber==salesnum).ToList();
            }//换货单号
            if (!string.IsNullOrEmpty(expressnum))
            {
                GetOrders = GetOrders.Where(t => t.WayBillNumber == expressnum).ToList();
            }//快递单号         1 支付宝   2微信

            if (!string.IsNullOrEmpty(telnum))
            {
                GetOrders = GetOrders.Where(t => t.BuyerAddressTel==telnum).ToList();
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
                GetOrders = GetOrders.Where(t => t.WayBillExpress ==(express)).ToList();
            }//快递公司
            if (!string.IsNullOrEmpty(salesex))
            {
                GetOrders = GetOrders.Where(t => t.ReturnSalesId==Convert.ToInt32( salesex)).ToList();
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
        [Route("/api/SalesDelAllAsync")]
        [HttpGet]
        public async Task<IActionResult> SalesDelAllAsync([FromQuery] string ids)
        {

            var del = await _electricityManagement.SalesDelAllAsync(ids);
            return Ok(del);
        }
    }
}
