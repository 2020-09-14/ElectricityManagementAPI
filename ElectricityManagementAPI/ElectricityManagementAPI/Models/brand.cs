using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    //品牌
    public class brand
    {
        public int Brandid { get; set; }//主键
        public string Img { get; set; }//图片
        public string Bname { get; set; }//品牌名称
        public string Corporation { get; set; }//企业名
    
        public bool State { get; set; }//状态
        public DateTime CreaTime { get; set; }//创建时间

    }
}
