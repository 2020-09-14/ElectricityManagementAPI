using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class OrdeCancelModel
    {
        //订单取消
        public int OrdeCancelId { get; set; }
        public string OrdeCancelCause { get; set; }
        public string OrdeCancelInfo { get; set; }
        public object OrdeCancelStateId { get; internal set; }
    }
}
