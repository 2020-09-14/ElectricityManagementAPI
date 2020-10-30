using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PromoteSalesControllers : ControllerBase
    {
        private IElectricityManagement _electricity;

        public PromoteSalesControllers(IElectricityManagement electricity)
        {
            _electricity = electricity;
        }


        [HttpGet]
        [Route("/api/GetShowActivity")]
        public async Task<IActionResult> GetShowActivities(int page, int limit, string States,string ActionName)
        {
            var  Activities = await _electricity.GetShowActivities(States,  ActionName);

           var count = Activities.Count;

          var list = Activities.Skip((page - 1) * limit).Take(limit).ToList();

          JsonData json = new JsonData {code=0,msg="",count=count+1,data=list };
           string jsons = JsonConvert.SerializeObject(json);
           return Ok(jsons);

        }


        //删除限时购活动(单删)
        [HttpPost]
        [Route("/api/DelActivities")]
        public async  Task<IActionResult> DelActivities(int id)
        {
            var a = (await _electricity.DelActivities(id));
            return Ok(a) ;
        }
        [HttpPost]
        [Route("/api/DelAllActivities")]
        //删除限时购活动(批删)
        public async   Task<IActionResult> DelAllActivities([FromForm]string ids)
        {
            var a=(await _electricity.DelAllActivities(ids));
            return Ok(a);
        }


        [HttpGet]
        [Route("/api/GetShowProduct")]
        public async Task<IActionResult> GetShowProduct(int page,int limit)
        {
            var Product = await _electricity.GetShowProduct();
            var count = Product.Count;
            var list = Product.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData json = new JsonData { code = 0, msg = "", count = count + 1, data = list };
            string  json1 = JsonConvert.SerializeObject(json);
            return Ok(json1);
        }
        //反填限时购
        [HttpGet]
        [Route("/api/fantian")]
        public async Task<IActionResult> Fan(int ids)
        {
            var Product = await _electricity.FantianActivities(ids);
           
            return Ok(Product);
        }
        //商品删除(单删)
        [HttpPost]
        [Route("/api/DelProduct")]
        public async Task<IActionResult> DelProduct(int id)
        {
            var a = (await _electricity.DelProduct(id));
            return Ok(a) ;
        }

        //商品删除(批删)
        [HttpPost]
        [Route("/api/DelAllProduct")]
        public async  Task<IActionResult> DelAllProduct([FromForm]string ids)
        {
            var a = (await _electricity.DelAllProduct(ids));
            return Ok(a);        
        }

        //新增限时购
        [HttpPost]
        [Route("/api/AddActivity")]
        public async Task<IActionResult> AddActivity([FromBody]activity model)
        {
            var a = (await _electricity.AddActivity(model));
            return Ok(a); 
        }


        //优惠券列表
        [HttpGet]
        [Route("/api/GetShowcoupon")]
        public async  Task <IActionResult> GetShowcoupon(int page, int limit, string type, string CouponName)
        {
            var Showcoupon = await _electricity.GetShowcoupon(type, CouponName);
            var count = Showcoupon.Count;
            var list = Showcoupon.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData jsons = new JsonData { code = 0, msg = "", count = count+1, data = Showcoupon };
            string json = JsonConvert.SerializeObject(jsons);
            return Ok(json);
        }

        //优惠券单删
        [HttpPost]
        [Route("/api/Delcoupon")]
        public async  Task<IActionResult> Delcoupon(int id)
        {
            var a = (await _electricity.Delcoupon(id));
            return Ok(a) ;
        }

        //优惠券批删
        [HttpPost]
        [Route("/api/DelAllcoupon")]
        public async  Task<IActionResult> DelAllcoupon([FromForm] string ids)
        {
            var a = (await _electricity.DelAllcoupon(ids));
            return Ok(a) ;
        
        }

        //新增优惠券
        [HttpPost]
        [Route("/api/Addcoupon")]
        public async Task<IActionResult> Addcoupon([FromBody]coupon model)
        {
            var a = (await _electricity.Addcoupon(model));
            return Ok(a) ;
        }

        //编辑限时购
       
        [Route("/api/EditActivities")]
        [HttpPost]
        public async Task<IActionResult> EditActivities([FromForm]activity model)
        {
            var a = (await _electricity.EditActivities(model));
            return Ok(a);
        }

        //编辑优惠券
        [HttpPost]
        [Route("/api/Editcoupon")]
        public async Task<IActionResult> Editcoupon([FromBody ]coupon model)
        {
            var a = (await _electricity.Editcoupon(model));
            return Ok(a);
        
        }

        //    var  Activities = await _electricity.GetShowActivities(States, UpTimes, DownTimes, ActionName);

        //    var count = Activities.Count;

        //    var list = Activities.Skip((page - 1) * pagesize).Take(pagesize).ToList();

        //    JsonData json = new JsonData {Code=0,Msg="",Count=count+1,Data=list };
        //    string jsons = JsonConvert.SerializeObject(json);
        //    return Ok(jsons);
        //显示广告
        [HttpGet]
        [Route("/api/GetShowland")]
        public async Task<IActionResult> GetShowland(int page,int limit,string LandingPageName, string UpState)
        {
            var land = await _electricity.GetShowland(LandingPageName, UpState);
            var count = land.Count;
            var list = land.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData json = new JsonData {code=0,msg="",count=count+1,data=land };
            var json1 = JsonConvert.SerializeObject(json);
            return Ok(json1);
        }

        //单删广告
        [HttpPost]
        [Route("/api/Delland")]
        public async Task<IActionResult> Delland(int id)
        {
            var a = (await _electricity.Delland(id));
            return Ok(a);
        }

        //批删广告
        [HttpPost]
        [Route("/api/DelAllland")]
        public async Task<IActionResult> DelAllland([FromForm] string ids)
        {
            var a = (await _electricity.DelAllland(ids));
            return Ok(a);
        }

        //新增广告
        [HttpPost]
        [Route("/api/Addland")]
        public async Task<IActionResult> Addland([FromBody]landingpage model)
        {
            var a = (await _electricity.Addland(model));
            return Ok(a);
        }


    }
}
