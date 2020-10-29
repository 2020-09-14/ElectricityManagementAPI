using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class landingpage
    {
        public int Lid { get; set; }
        public string  LandingPageName { get; set; }
        public string  ProImage { get; set; }
        public int PageVime { get; set; }
        public int Sales { get; set; }
        public DateTime CreaTime { get; set; }
        public string  UpState { get; set; }
    }
}
