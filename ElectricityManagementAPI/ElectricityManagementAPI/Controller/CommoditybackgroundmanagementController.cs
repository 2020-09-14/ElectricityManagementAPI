using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ElectricityManagementAPI.Dal;
using ElectricityManagementAPI.Models;
using ElectricityManagementAPI.Helper;
using Newtonsoft.Json;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MySqlX.XDevAPI.Relational;

namespace ElectricityManagementAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommoditybackgroundmanagementController : ControllerBase
    {
        IElectricityManagement electricity;
        public CommoditybackgroundmanagementController(IElectricityManagement electricityManagement)
        {
            electricity = electricityManagement;
        }
        //分类显示
        [Route("/api/claShow")]
        [HttpGet]
        public async Task<IActionResult> ClassShow(int page, int rows)
        {
            List<Classify> GetList = await electricity.ClassShow();
            int count = GetList.Count;
            GetList = GetList.Skip((page - 1) * rows).Take(rows).ToList();
            var model = new
            {
                count = count,
                list = GetList
            };

            return Ok(model);
        }
        //还原
        [Route("/api/Huan")]
        [HttpGet]
        public IActionResult Huan(string ids)
        {
            return Ok(electricity.Huan(ids));
        }
        //品牌
        [Route("/api/Pinpai")]
        [HttpGet]
        public async Task<IActionResult> BrandsAsync(int page, int rows)
        {
            List<brand> Getshow = await electricity.BrandAsync();
            int count = Getshow.Count;
            Getshow = Getshow.Skip((page - 1) * rows).Take(rows).ToList();
            var model = new
            {
                count = count,
                list = Getshow
            };
            
            return Ok(model);
        }
        //品牌
        [Route("/api/Pinpai2")]
        [HttpGet]
        public async Task<IActionResult> BrandsAsync2()
        {
            List<brand> Getshow = await electricity.BrandAsync();
            
          
            return Ok(Getshow);
        }
        //商品
        [Route("/api/WcGoods")]
        [HttpGet]
        public async Task<IActionResult> CommoditiesAsync(int page,int rows,string ids, string classIfyId,string creaTime,string delTime, string inventory1,string inventory2,string name,string bian,string price1,string price2)
        {
            List<Commodity> Getshow = await electricity.commoditiesAsync();
            var count = Getshow.Count;
            var list = Getshow.Skip((page - 1) * rows).Take(rows).ToList();
            if (!string.IsNullOrEmpty(classIfyId))
            {
                list = list.Where(p => p.CommodityId == Convert.ToInt32(classIfyId)).ToList();
            }
            if (!string.IsNullOrEmpty(creaTime))
            {
                list = list.Where(p => p.CreaTime >= Convert.ToDateTime(creaTime)).Where(p => p.CreaTime <= Convert.ToDateTime(delTime)).ToList();
            }
            if (!string.IsNullOrEmpty(inventory1)|| !string.IsNullOrEmpty(inventory2))
            {
                list = list.Where(p =>Convert.ToInt32(p.Inventory) >= Convert.ToInt32(inventory1)).Where(p => Convert.ToInt32(p.Inventory) <= Convert.ToInt32(inventory2)).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(p => p.SCname.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(ids))
            {
                list = list.Where(p => p.State==Convert.ToInt32(ids)).ToList();
            }
            if (!string.IsNullOrEmpty(bian))
            {
                
                   list = list.Where(p => p.CommodityId == Convert.ToInt32(bian)).ToList();
            }
            if (!string.IsNullOrEmpty(price1) || !string.IsNullOrEmpty(price2))
            {
                list = list.Where(p => Convert.ToInt32(p.Price) >= Convert.ToInt32(price1)).Where(p => Convert.ToInt32(p.Price) <= Convert.ToInt32(price1)).ToList();
            }
            var model = new
            {
                count = count,
                list = list
            };
            return Ok(model);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Route("/api/DelComm")]
        [HttpGet]
        public async Task<int> DelCommAsync(string ids)
        {
            return await electricity.DelCommAsync(ids);
        }
        /// <summary>
        /// 上传图片,通过Form表单提交
        /// </summary>
        /// <returns></returns>
        [Route("/Upload/FormImg")]
        [HttpPost]
        public IActionResult UploadImg(List<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            if (files.Count < 1)
            {
                return Ok("文件为空");
            }
            //返回的文件地址
            List<string> filenames = new List<string>();
            var now = DateTime.Now;
            //文件存储路径
            var filePath = string.Format("/Images/");
            //获取当前web目录
            var webRootPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(webRootPath + filePath))
            {
                Directory.CreateDirectory(webRootPath + filePath);
            }
            try
            {
                foreach (var item in files)
                {
                    if (item != null)
                    {
                        #region  图片文件的条件判断
                        //文件后缀
                        var fileExtension = Path.GetExtension(item.FileName);

                        //判断后缀是否是图片
                        const string fileFilt = ".gif|.jpg|.jpeg|.png";
                        if (fileExtension == null)
                        {
                            break;
                            //return Error("上传的文件没有后缀");
                        }
                        if (fileFilt.IndexOf(fileExtension.ToLower(), StringComparison.Ordinal) <= -1)
                        {
                            break;
                            //return Error("请上传jpg、png、gif格式的图片");
                        }

                        //判断文件大小    
                        long length = item.Length;
                        if (length > 1024 * 1024 * 2) //2M
                        {
                            break;
                            //return Error("上传的文件不能大于2M");
                        }

                        #endregion

                        var strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff"); //取得时间字符串
                        var strRan = Convert.ToString(new Random().Next(100, 999)); //生成三位随机数
                        var saveName = strDateTime  + fileExtension;

                        //插入图片数据                 
                        using (FileStream fs = System.IO.File.Create(webRootPath + filePath + saveName))
                        {
                            item.CopyTo(fs);
                            fs.Flush();
                        }
                        filenames.Add(filePath + saveName);
                    }
                }
                

                return Ok(filenames);
            }
            catch (Exception ex)
            {
                //这边增加日志，记录错误的原因
                //ex.ToString();
                return Ok("上传失败");
            }
        }
      
        //品牌添加
        [Route("/api/Brandadd")]
        [HttpPost]
        public async Task<IActionResult> BreadAddAsync([FromForm]brand b)
        {
            return Ok(await electricity.BrandAddAsync(b));
        }
        //分类父级
        [Route("/api/Claf")]
        public async Task<IActionResult> Classifies()
        {
            return Ok(await electricity.Classifies());
        }
        //分类子集
        [Route("/api/GetClaf")]
        [HttpGet]
        public async Task<IActionResult> GetClassifies(int ids)
        {
            return Ok(await electricity.GetClassifies(ids));
        }
        //添加商品
        [Route("/api/CommAdd")]
        [HttpPost]
        public async Task<IActionResult> CommAddAsunc([FromBody]Commodity b)
        {
            var aa = await electricity.CommAddAsunc(b);
            return Ok(aa);
        }
        //所有规格
        [Route("/api/spec")]
        [HttpGet]
        public async Task<List<Specification>> specAsunc()
        {
            return await electricity.specAsunc();
        }
        //商品详情
        [Route("/api/Xq")]
        [HttpGet]
        public Commodity Xq([FromQuery]string ids)
        {
            return electricity.Xq(ids);
        }
        //商品上架
        [Route("/api/Sj")]
        [HttpGet]
        public IActionResult Sj([FromQuery] string ids)
        {
            return Ok( electricity.Sj(ids));
        }
        //删除回收站的商品
        
        [Route("/api/Sj")]
        [HttpGet]
        public async Task<IActionResult> CommDelete(string ids)
        {
            return Ok(await electricity.CommDelete(ids));

        }
        //商品回收站
        [Route("/api/WcDelGoods")]
        [HttpGet]
        public async Task<IActionResult> CommodeleteAsync(int page, int rows, string ids, string classIfyId, string creaTime, string delTime, string name, string bian)
        {
            List<Commodity> Getshow = await electricity.commodeleteAsync();
            var count = Getshow.Count;
            var list = Getshow.Skip((page - 1) * rows).Take(rows).ToList();
            if (!string.IsNullOrEmpty(classIfyId))
            {
                list = list.Where(p => p.Cidd == Convert.ToInt32(classIfyId)).ToList();
            }
            if (!string.IsNullOrEmpty(creaTime))
            {
                list = list.Where(p => p.CreaTime >= Convert.ToDateTime(creaTime)).Where(p => p.CreaTime <= Convert.ToDateTime(delTime)).ToList();
            }
           
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(p => p.SCname.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(ids))
            {
                list = list.Where(p => p.State == Convert.ToInt32(ids)).ToList();
            }
            if (!string.IsNullOrEmpty(bian))
            {

                list = list.Where(p => p.CommodityId == Convert.ToInt32(bian)).ToList();
            }
           
            var model = new
            {
                count = count,
                list = list
            };
            return Ok(model);
        }
        //商品评论
        [Route("/api/Remark")]
        [HttpGet]
        public async Task<IActionResult> EvaluateAsync(int page, int rows,string fenlei,string creatime,string deltime, string dengji,string stars,string scname,string userinfo,string phone)
        {
            List<Evaluate> Getshow = await electricity.EvaluatesAsync();
            var count = Getshow.Count;
            var list = Getshow.Skip((page - 1) * rows).Take(rows).ToList();
            if (!string.IsNullOrEmpty(fenlei))
            {
                list = list.Where(p => p.Cidd == Convert.ToInt32(fenlei)).ToList();
            }
            if (!string.IsNullOrEmpty(creatime)&& !string.IsNullOrEmpty(deltime))
            {
                list = list.Where(p => p.Creatime>= Convert.ToDateTime(creatime)).Where(p=>p.Creatime<=Convert.ToDateTime(deltime)).ToList();
            }
            if (!string.IsNullOrEmpty(dengji))
            {
                list = list.Where(p => p.stars == dengji).ToList();
            }
            if (!string.IsNullOrEmpty(stars))
            {
                list = list.Where(p => p.state == Convert.ToBoolean(stars)).ToList();
            }
            if (!string.IsNullOrEmpty(scname))
            {
                list = list.Where(p => p.SCname.Contains(scname)).ToList();
            }
            if (!string.IsNullOrEmpty(userinfo))
            {
                list = list.Where(p => p.BuyerInfoName.Contains(userinfo)).ToList();
            }
            if (!string.IsNullOrEmpty(phone))
            {
                list = list.Where(p => p.BuyerInfoTel== phone).ToList();
            }
            var model = new
            {
                count = count,
                list = list
            };
            return Ok(model);
        }
        //删除评论
        [Route("/api/DelPing")]
        [HttpGet]
        public async Task<int> EvaluateDel(string ids)
        {
            return await electricity.EvaluateDel(ids);
        }
        //规格显示
        [Route("/api/SpcifiShow")]
        [HttpGet]
        public async Task<IActionResult> Specifications(int page,int rows,string state,string name)
        {
            List<Specification> Getshow = await electricity.Specifications();
            var count = Getshow.Count;
            var list = Getshow.Skip((page - 1) * rows).Take(rows).ToList();
            if (!string.IsNullOrEmpty(state))
            {
                list = list.Where(p => p.Steate == Convert.ToBoolean(state)).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(p => p.Sname.Contains(name)).ToList();
            }
            var model = new
            {
                count = count,
                list = list
            };
            return Ok(model) ;
        }
        //删除规格
        [Route("/api/SpDel")]
        [HttpGet]
        public async Task<int> SpDel(string ids)
        {
            return await electricity.SpDel(ids);
        }
        //添加规格
        [Route("/api/SpAdd")]
        [HttpPost]
        public async Task<int> SpAdd([FromBody]Specification s)
        {
            return await electricity.SpAdd(s);
        }
        //修改规格
        [Route("/api/SpUpt")]
        [HttpPost]
        public async Task<int> SpUpt([FromBody]Specification s)
        {
            return await electricity.SpUpt(s);
        }
        //反填规格
        [Route("/api/SpFt")]
        [HttpGet]
        public Specification SpFt(string ids)
        {
            return  electricity.SpFt(ids);
        }
    }
}
