using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class BuyerInfoModel
    {
        //买家信息
        public int BuyerInfoId { get; set; }
        public string BuyerInfoName { get; set; }
        public string BuyerInfoTel { get; set; }
        public string BuyerInfoMess { get; set; }
        public int BuyerInfoPlace { get; set; }
        //买家地址表
        public int BuyerAddressId { get; set; }
        public string BuyerAddressName { get; set; }
        public string BuyerAddressInfo { get; set; }
        public string BuyerAddressTel { get; set; }
    }
}
