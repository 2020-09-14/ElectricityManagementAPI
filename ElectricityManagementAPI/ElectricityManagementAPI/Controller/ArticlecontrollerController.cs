using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Helper;
using ElectricityManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ElectricityManagementAPI.Controller
{

    //文章控制器

    [Route("api/[controller]")]
    [ApiController]
    public class ArticlecontrollerController : ControllerBase
    {
        private IElectricityManagement _electricity;

        public ArticlecontrollerController(IElectricityManagement electricity)
        {
            _electricity = electricity;
        }

        
        [HttpGet]
        [Route("/api/GetShow")]
        public async Task<IActionResult> GetShow()
        {
            var Getshow = await _electricity.GetShowAsync();

            JsonData jsons = new JsonData { code = 0, msg = "", count = 100, data = Getshow };

           

            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }
    }
}
