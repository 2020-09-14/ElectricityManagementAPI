using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class commodityAdd
    {
        public int commodityAddId { get; set; }
        public int Price1 { get; set; }
        public int MarkingPrice { get; set; }
        public int ActivityStock { get; set; }
        public int Sort { get; set; }
        public int commodityId { get; set; }
        public int Price { get; set; }
        public string SCname { get; set; }
    }
}
