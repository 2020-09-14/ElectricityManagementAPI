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


        
        //文章显示

        //显示所有的商品

        [HttpGet]
        [Route("/api/GetShow")]
        public async Task<IActionResult> GetShow(int page,int limit)
        {

            var Getshows = await _electricity.GetShowAsync();
            var COunt = Getshows.Count();
            var liat = Getshows.Skip((page  - 1)*limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = COunt+1, data = liat };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }

        //文章类型绑定
        [HttpGet]
        [Route("/api/Binding")]
        public async Task<IActionResult> Binding()
        {
            var Bindings = await _electricity.BindingAsync();
            string json = JsonConvert.SerializeObject(Bindings);
            return Ok(json);
        }

        //文章查询
        [HttpGet]
        [Route("/api/Thisqueries")]
        public async Task<IActionResult> ThisqueriesAsync(int page, int limit, string Title, string Sort)
        {
            var ThisqueriesAsyncs = await _electricity.ThisqueriesAsync(Title, Sort);
            var COunt = ThisqueriesAsyncs.Count();
            var liat = ThisqueriesAsyncs.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = COunt + 1, data = liat };

            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }

        //文章删除
        [HttpPost]
        [Route("/api/DelmethodsAsync")]
        public async Task<IActionResult> DelmethodsAsync([FromForm]string SId)
        {
            var DelmethodsAsyncs = await _electricity.DelmethodsAsync(SId);
            
            return Ok(DelmethodsAsyncs);
        }

        //文章添加
        [HttpPost]
        [Route("/api/AdditionAsync")]
        public async Task<IActionResult> AdditionAsync([FromForm]Article ar)
        {
            var Addition = await _electricity.AdditionAsync(ar);
            return Ok(Addition);
        }


        //删除类
        [HttpPost]
        [Route("/api/DelLeiAsync")]
        public async Task<IActionResult> DelLeiAsync([FromForm]string DId)
        {
            var DelLei = await _electricity.DelLeiAsync(DId);
            return Ok(DelLei);
        }

        //分类显示
        [HttpGet]
        [Route("/api/FenLeiAsync")]
        public async Task<IActionResult> FenLeiAsync(int page, int limit, string Ti, string FName)
        {
            var FenLei = await _electricity.FenLeiAsync(Ti, FName);
            var COunt = FenLei.Count();
            var liat = FenLei.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = COunt + 1, data = liat };


            string json = JsonConvert.SerializeObject(jsons);

            return Ok(json);
        }

        //评论查询
        [HttpGet]
        [Route("/api/ReviewAsync")]
        public async Task<IActionResult> ReviewAsync(int page, int limit,string NName,string PNei,string Lei)
        {
            var Review = await _electricity.ReviewAsync(Lei);

            if (!string.IsNullOrEmpty(NName))
            {
                Review = Review.Where(st => st.UserName.Contains(NName)).ToList();
            }
            if (!string.IsNullOrEmpty(PNei))
            {
                Review = Review.Where(st => st.Content.Contains(PNei)).ToList();
            }
            

            var Count = Review.Count;
            var liat = Review.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = Count, data = liat };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }

        //文章评论删除
        [HttpPost]
        [Route("/api/DelLunAsync")]
        public async Task<IActionResult> DelLunAsync([FromForm]string MId)
        {
            var DelLun = await _electricity.DelLunAsync(MId);

            return Ok(DelLun);
        }

        //类型添加
        [HttpPost]
        [Route("/api/LeiAddAsync")]
        public async Task<IActionResult> LeiAddAsync([FromBody]Category ca)
        {
            var LeiAdd = await _electricity.LeiAddAsync(ca);
            return Ok(LeiAdd);
        }
    }
}
