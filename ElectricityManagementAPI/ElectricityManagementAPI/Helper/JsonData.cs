using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Helper
{
    public class JsonData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public object data { get; set; }
    }
}
