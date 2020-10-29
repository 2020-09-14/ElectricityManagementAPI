using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeliverController : ControllerBase
    {
        private IElectricityManagement _electricityManagement;
        public DeliverController(IElectricityManagement electricityManagement)
        {
            _electricityManagement = electricityManagement;
        }


        [HttpGet]
        public async Task<IActionResult> GetDeliver(int page,int pageSize,string begintime,string overtime,string state, 
                string paytype, string goodsname,string express, string shoupeo, string tels,string deliver)
        {
            List<WayBillModel> GetDelivers = await _electricityManagement.GetWayBills();
            if (!string.IsNullOrEmpty(begintime) || !string.IsNullOrEmpty(overtime))
            {

                GetDelivers = GetDelivers.Where(t => t.WayBillTime > Convert.ToDateTime(begintime) && t.WayBillTime < Convert.ToDateTime(overtime)).ToList();
            }//时间查询


            if (!string.IsNullOrEmpty(state))
            {
                GetDelivers = GetDelivers.Where(t => t.WayBillState==Convert.ToInt32(state)).ToList();
            }//运单状态查询
            if (!string.IsNullOrEmpty(paytype))
            {
                GetDelivers = GetDelivers.Where(t => t.OrderPay == Convert.ToInt32(paytype)).ToList();
            }//支付类型         1 支付宝   2微信
            if (!string.IsNullOrEmpty(goodsname))
            {
                GetDelivers = GetDelivers.Where(t => t.GoodsName.Contains(goodsname)).ToList();
            }//商品名称
            if (!string.IsNullOrEmpty(express))
            {
                GetDelivers = GetDelivers.Where(t => t.WayBillExpress==(express)).ToList();
            }//快递公司
            if (!string.IsNullOrEmpty(shoupeo))
            {
                GetDelivers = GetDelivers.Where(t => t.BuyerAddressName.Contains(shoupeo)).ToList();
            }//收货人
            if (!string.IsNullOrEmpty(tels))
            {
                GetDelivers = GetDelivers.Where(t => t.BuyerAddressTel == (tels)).ToList();
            }//用户电话
            if (!string.IsNullOrEmpty(deliver))
            {
                GetDelivers = GetDelivers.Where(t => t.WayBillNumber == (deliver)).ToList();
            }//运单号
            var count = GetDelivers.Count;
            GetDelivers = GetDelivers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var model = new
            {
                counts = count,
                lists = GetDelivers
            };
            return Ok(model);

            
        }
        [HttpPost]
        [Route("/api/UptAll")]
        public async Task<IActionResult> UptAll([FromBody]OrdeCancelModel c)
        {
            var aa = await _electricityManagement.UptAdd(c);
            return Ok(aa);
        }
        [Route("/api/GetordeCancel")]
        [HttpGet]
        public async Task<IActionResult> GetordeCancel(int page,int pageSize)
        {
            var orde = await _electricityManagement.GetOrdeCancels();
            var count = orde.Count;
            orde = orde.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var model = new
            {
                counts = count,
                lists = orde
            };
            return Ok(model);
        }
        [Route("/api/DelordeAll")]
        [HttpGet]
        public async Task<IActionResult> DelordeAll([FromQuery] string ids)
        {

            var del = await _electricityManagement.DelredeAllAsync(ids);
            return Ok(del);
        }


        [Route("/api/GetOrdeEdit")]
        [HttpGet]
        public async Task<IActionResult> GetOrdeEdit(int ids)
        {
            var orde = await _electricityManagement.GetOrdeEdit(ids);
            return Ok(orde);
        }

        [Route("/api/UptCancel")]
        [HttpPost]
        public async Task<IActionResult> UptCancel([FromBody] OrdeCancelModel c)
        {
            var orde = await _electricityManagement.Uptcancel(c);
            return Ok(orde);
        }
        [Route("/api/AddCancel")]
        [HttpPost]
        public async Task<IActionResult> AddCancel([FromBody] OrdeCancelModel c)
        {
            var orde = await _electricityManagement.Addcancel(c);
            return Ok(orde);
        }
    }
  
    //int states, string ordernum, string paytype, string buyerliu, string begintime, string overtime, string goodsname, string goodsnum, string buyername,  string tel, int page, int pageSize

}

