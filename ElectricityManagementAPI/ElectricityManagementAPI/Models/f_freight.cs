using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 运费模板表
    /// </summary>
    public class f_freight
    {
        public int Fid { get; set; }
        public string FName{ get; set; }
        public int Fregin { get; set; }
        public bool Fcarriage { get; set; }
        public bool Fvaluation { get; set; }
        public int Fpice { get; set; }
        public float Felement { get; set; }
        public int Fletter { get; set; }
        public float Funit { get; set; }
        public DateTime Fdatetiem { get; set; }
        public bool Fstate { get; set; }
        public bool Fcondition { get; set; }
    }
}
