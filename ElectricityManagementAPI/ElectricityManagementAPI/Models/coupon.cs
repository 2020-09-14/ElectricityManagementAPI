using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class coupon
    {

        public int Cid { get; set; }
        public string  CouponNumber { get; set; }
        public string  CouponName { get; set; }
        public string  Type { get; set; }
        public string  Facevalue { get; set; }
        public DateTime UsefulTime { get; set; }
        public string  Circulation { get; set; }
        public int Privatestate { get; set; }
        public string  UseRange { get; set; }
        public int Limit { get; set; }
        public string  Remarks { get; set; }
    }
}
