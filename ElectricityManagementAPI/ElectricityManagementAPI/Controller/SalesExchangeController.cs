using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SalesExchangeController : ControllerBase
    {
        private IElectricityManagement _electricity;

        public SalesExchangeController (IElectricityManagement electricity)
        {
            _electricity = electricity;
        }

        //退货原因显示
        [HttpGet]
        [Route("/api/TuiShowAsync")]
        public async Task<IActionResult> TuiShowAsync(int page,int limit)
        {
            var TuiShow = await _electricity.TuiShowAsync();
            var COunt = TuiShow.Count();
            var liat = TuiShow.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = COunt + 1, data = liat };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }
        //退货原因删除
       [HttpPost]
       [Route("/api/DELReturnAsync")]
       public async Task<IActionResult> DELReturnAsync([FromForm]string SId)
        {
            var DELReturn = await _electricity.DELReturnAsync(SId);
            return Ok(DELReturn);
        }

        //退货添加
        [HttpPost]
        [Route("/api/ADDReturnAsync")]
        public async Task<IActionResult> ADDReturnAsync(SalesExchangeModel sa)
        {
            var ADDReturn = await _electricity.ADDReturnAsync(sa);
            return Ok(ADDReturn);
        }

        //注册
        [HttpPost]
        [Route("/api/loginAsync")]
        public async Task<int> LoginAsync([FromBody]UserInfo de)
        {
            var Login = await _electricity.LoginAsync(de);
            int code = Login;
            return code;
        }

        //登录
        [HttpGet]
        [Route("/api/registerAsync")]
        public async Task<int> RegisterAsync(string DName, string DMi)
        {
            var Register = await _electricity.RegisterAsync(DName, DMi);
            int code = Register;
            return code;

        }

    }
}
