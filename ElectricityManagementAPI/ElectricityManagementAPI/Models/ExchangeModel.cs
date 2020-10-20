using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class ExchangeModel
    {
        //换货列表
        public int ExchangeId { get; set; }
        public string ExchangeNumber { get; set; }
        public DateTime ExchangeTime { get; set; }
        public int ReturnExchangeId { get; set; }
        public int ExchangeState { get; set; }
        public int ExchangeOrderId { get; set; }

        //退换货原因
        public int SalesExchangeId { get; set; }


        public string SalesExchangeCause { get; set; }
        public string SalesExchangeInfo { get; set; }
    }
}
