using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Helper;
using ElectricityManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElectricityManagementAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurisdictionController : ControllerBase
    {
        private IElectricityManagement _electricity;
        public JurisdictionController(IElectricityManagement electricityManagement)
        {
            _electricity = electricityManagement;
        }

        //显示角色信息
        [Route("/api/ShowRoles")]
        [HttpGet]
        public async Task<IActionResult> ShowRoles(int page,int limit,string RName, string RCreator)
        {
            var GetRoles = await _electricity.ShowRolesAsync(RName,RCreator);
            var count = GetRoles.Count();
            var list = GetRoles.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsonss = new JsonData { code = 0, msg = "", count = count + 1, data = list };
            string json = JsonConvert.SerializeObject(jsonss);
            return Ok(json);
        }
        //显示功能信息
        [Route("/api/ShowFunction")]
        [HttpGet]
        public async Task<IActionResult> ShowFunction(int page, int limit, string FName, string FCoding)
        {
            var GetFunction = await _electricity.ShowFunctionAsync(FName, FCoding);
            var count = GetFunction.Count();
            var list = GetFunction.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = count + 1, data = list };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }
        //显示组织信息
        [Route("/api/ShowTissue")]
        [HttpGet]
        public async Task<IActionResult> ShowTissues(int limit,int page,string TLinkman, string TName)
        {
            var GetTissues = await _electricity.ShowTissueAsync(TLinkman,TName);
            var count = GetTissues.Count();
            var list = GetTissues.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = count + 1, data = list };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }
        //删除角色信息
       [Route("/api/DelRoles")]
       [HttpGet]
        public async Task<int> DelRoles([FromQuery]string ids)
       {
            return await _electricity.DelRolesAsync(ids);
       }
        //编辑角色信息
        [Route("/api/UptRoles")]
        [HttpPost]
        public async Task<int> UptRoles([FromForm]Roles r)
        {
            return await _electricity.UptRolesAsync(r);
        }
        //添加角色信息
        [Route("/api/AddRoles")]
        [HttpPost]
        public async Task<IActionResult> AddRoles([FromBody]Roles r)
        {
            int i = (await _electricity.AddRolesAsync(r));
            return Ok(i);
        }
        //绑定下拉显示部门
        [Route("/api/BindDepartment")]
        [HttpGet]
        public async Task<IActionResult> BindDepartment()
        {
            var json = await _electricity.BindDepartmentAsync();
            var json1 = JsonConvert.SerializeObject(json);
            return Ok(json1);
        }
        //添加组织信息
        [Route("/api/AddTissue")]
        [HttpPost]
        public async Task<IActionResult> AddTissue([FromBody]Tissue t)
        {
            int i = (await _electricity.AddTissueAsync(t));
            return Ok(i);
        }
        //添加功能信息
        [Route("/api/AddFunction")]
        [HttpPost]
        public async Task<IActionResult> AddFunction([FromBody]Function f)
        {
            int i = (await _electricity.AddFunctionAsync(f));
            return Ok(i);
        }
        //删除组织信息
        [Route("/api/DelTissue")]
        [HttpGet]
        public async Task<IActionResult> DelTissue([FromQuery]string ids)
        {
            int i= (await _electricity.DelTissueAsync(ids));
            return Ok(i);
        }
        //删除功能信息
        [Route("/api/DelFunction")]
        [HttpGet]
        public async Task<IActionResult> DelFunction([FromQuery]string ids)
        {
            int i = (await _electricity.DelFunctionAsync(ids));
            return Ok(i);
        }
        //修改组织信息
        [Route("/api/UptTissue")]
        [HttpPost]
        public async Task<IActionResult> UptTissue(Tissue t)
        {
            int i = (await _electricity.UptTissueAsync(t));
            return Ok(i);
        }
        //反填组织信息
        [Route("/api/FanTissue")]
        [HttpGet]
        public async Task<IActionResult> FanTissue([FromQuery]int ids)
        {
            var list = await _electricity.FanTissueAsync(ids);
            string json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }
        //反填角色信息
        [Route("/api/FanTissue")]
        [HttpGet]
        public async Task<IActionResult> FanRoles([FromQuery] int ids)
        {
            var list = await _electricity.FanRolesAsync(ids);
            string json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }
        //反填功能信息
        [Route("/api/FanTissue")]
        [HttpGet]
        public async Task<IActionResult> FanFunction([FromQuery] int ids)
        {
            var list = await _electricity.FanFunctionAsync(ids);
            string json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }
    }
}
