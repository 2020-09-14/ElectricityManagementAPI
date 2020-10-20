using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class BuyerAddressModel
    {
        //买家地址表
        public int BuyerAddressId { get; set; }
        public string BuyerAddressName { get; set; }
        public string BuyerAddressInfo { get; set; }
        public string BuyerAddressTel { get; set; }
     
    }
}
