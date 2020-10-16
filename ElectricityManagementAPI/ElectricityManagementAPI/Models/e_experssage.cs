using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 快递公司表
    /// </summary>
    public class e_experssage
    {
        public int Eid{ get; set; }
        public string EName { get; set; }
        public string Ephone { get; set; }
        public string Eofficial { get; set; }
    }
}
