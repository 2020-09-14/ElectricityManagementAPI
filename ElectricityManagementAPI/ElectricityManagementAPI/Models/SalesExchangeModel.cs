using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class SalesExchangeModel
    {
        //退换货原因
        public int SalesExchangeId { get; set; }


        public string SalesExchangeCause { get; set; }
        public string SalesExchangeInfo { get; set; }
    }
}
