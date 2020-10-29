using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class activity
    {
        public int Id { get; set; }
        public string  Number  { get; set; }
        public string  Name { get; set; }
        public DateTime Uptime { get; set; }
        public DateTime DownTime { get; set; }
        public int Count { get; set; }
        public string  State { get; set; }
        public string  PhImage { get; set; }
        public string  PcImage { get; set; }
        public string  Rule { get; set; }
    }
}
