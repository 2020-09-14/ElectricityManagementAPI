using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Models;
using ElectricityManagementAPI.Helper;
using Newtonsoft.Json;

namespace ElectricityManagementAPI.Controller
{
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
        [Route("/api/GetShowAsync")]
        public async Task<IActionResult> GetShowAsync(int page,int limit)
        {
            var GetAddresses = await _management.GetAddressesAsync();
            var Acount = GetAddresses.Count();
            var list = GetAddresses.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = Acount+1, data = list };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }
        //显示快递公司表
        [HttpGet]
        [Route("/api/ExperssagesAsync")]
        public Task<List<e_experssage>> ExperssagesAsync(string Ephone, string EName)
        {
            return _management.GetExperssagesAsync(Ephone, EName);
        }
        //显示运费模板
        [HttpGet]
        [Route("/api/FreightsAsync")]
        public Task<List<f_freight>> FreightsAsync()
        {
            return _management.GetFreightsAsync();
        }
        //显示包裹中心
        [HttpGet]
        [Route("/api/GetPackagesAsync")]
        public Task<List<p_package>> GetPackagesAsync() 
        {
            return _management.GetPackagesAsync();
        }
        //添加运费模板
        [HttpPost]
        [Route("/api/GetFreightsAsync")]
        public Task<int> GetFreightsAsync([FromForm]f_freight model) 
        {
            return _management.AddFreightAsync(model);
        }
        //添加网点申请
        [HttpPost]
        [Route("/api/GetFreightsAsync")]
        public Task<int> AddBranchAsync([FromForm]b_branch model) 
        {
            return _management.AddBranchAsync(model);
        }
        //添加京东申请
        [HttpPost]
        [Route("/api/GetFreightsAsync")]
        public Task<int> AddBranchAsync([FromForm] j_jingdong model) 
        {
            return _management.AddJingdongAsync(model);
        }
        //添加地址
        [HttpPost]
        [Route("/api/AddAddressAsync")]
        public Task<int> AddAddressAsync([FromForm] a_address model) 
        {
            return _management.AddAddressAsync(model);
        }
    }
}
