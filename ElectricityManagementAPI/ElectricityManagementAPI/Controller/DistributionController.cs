using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Helper;
using ElectricityManagementAPI.Models;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Controller
{
    /// <summary>
    /// 物流管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        private IElectricityManagement _management;
        public DistributionController(IElectricityManagement electricity)
        {
            _management = electricity;
        }

        //显示地址
        [HttpGet]
        [Route("/api/GetAddressesAsync")]
        public async Task<IActionResult> GetAddressesAsync()
        {
            var josn = await _management.GetAddressesAsync();
            var list = JsonConvert.SerializeObject(josn);
            return Ok(list);
        }
        //显示快递公司表
        [HttpGet]
        [Route("/api/ExperssagesAsync")]
        public async Task<IActionResult> ExperssagesAsync(string EName, string Eofficial)
        {
            var josn = await _management.GetExperssagesAsync(EName,Eofficial);
            var list = JsonConvert.SerializeObject(josn);
            return Ok(list);
        }
        //显示包裹中心
        [HttpGet]
        [Route("/api/PackagesAsync")]
        public async Task<IActionResult> PackagesAsync(string Pstate, string EName, string Podd, string Pordernumber, string Panomaly)
        {
            var json = await _management.GetPackagesAsync(Pstate,EName,Podd,Pordernumber,Panomaly);
            var list = JsonConvert.SerializeObject(json);
            return Ok(list);
        }
        
        //详情页（快递公司）
        [HttpGet]
        [Route("/api/DetailsExperssagesAsync")]
        public async Task<IActionResult> DetailsExperssagesAsync(int id) 
        {
            var details =await  _management.DetailsExperssagesAsync(id);
            string json = JsonConvert.SerializeObject(details);
            return Ok(json);
        }
        //修改（设为收货地址）
        [HttpPost]
        [Route("/api/UpdAddressAsync")]
        public async Task<IActionResult> UpdAddressAsync(int id) 
        {
            int i = await _management.UpdAddressAsync(id);
            return Ok(i);
        }
        //添加网点
        [HttpPost]
        [Route("/api/AddBranchAsync")]
        public async Task<IActionResult> AddBranchAsync([FromBody]b_branch b) 
        {
            int list = (await _management.AddBranchAsync(b));
            return Ok(list);
        }
        //删除地址
        [HttpPost]
        [Route("/api/DelAddressAsync")]
        public async Task<IActionResult> DelAddressAsync(int id) 
        {
            int list = (await _management.DelAddressesAsync(id));
            return Ok(list);
        }
        //添加地址
        [HttpPost]
        [Route("/api/AddAddressAsync")]
        public async Task<IActionResult> AddAddressAsync([FromBody]a_address a) 
        {
            int list = (await _management.AddAddressesAsync(a));
            return Ok(list);
        }
        //反填地址
        [HttpPost]
        [Route("/api/FandAddressAsync")]
        public async Task<IActionResult> FandAddressAsync(int id) 
        {
            var details = await _management.FandAddressAsync(id);
            string json = JsonConvert.SerializeObject(details);
            return Ok(json);
        }
        //更新地址 
        [HttpPost]
        [Route("/api/UptAddressAsync")]
        public async Task<IActionResult> UptAddressAsync([FromBody]a_address a) 
        {
            
            int list = (await _management.UptAddressAsync(a));
            return Ok(list);
        }
        //详情页（包裹中心）
        [HttpPost]
        [Route("/api/DetailsPackageAsync")]
        public async Task<IActionResult> DetailsPackageAsync(int id) 
        {
            string json = JsonConvert.SerializeObject(await _management.DetailsPackageAsync(id));
            return Ok(json);
        }
        //更新地址 
        [HttpPost]
        [Route("/api/AddPackagesAsync")]
        public async Task<IActionResult> AddPackagesAsync([FromForm]p_package p)
        {
            int i = await _management.AddPackagesAsync(p);
            return Ok(i);
        }
    }
}
