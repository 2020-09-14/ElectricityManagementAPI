using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class SalesModel
    {
        //退货列表
        public int SalesId { get; set; }
        public string SalesNumber { get; set; }
        public DateTime SalesTime { get; set; }
        public string ReturnSalesId { get; set; }
        public int SalesState { get; set; }
        public int SalesOrderId { get; set; }
        //退换货原因
        public int SalesExchangeId { get; set; }


        public string SalesExchangeCause { get; set; }
        public string SalesExchangeInfo { get; set; }
    }
}
