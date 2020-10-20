using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class GoodsModel
    {
        //商品
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImg { get; set; }
        public string GoodsIntroduce { get; set; }
        public int GoodsNum { get; set; }
        public float GoodsPrice { get; set; }
    }
}
