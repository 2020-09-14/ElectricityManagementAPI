using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    //规格表
    public class Specification
    {
        public int SpecificationId { get; set; }//主键
        public string Sname { get; set; }//规格名称
        public bool Steate { get; set; }//状态
        public DateTime CreaTime { get; set; }//创建时间
        public bool State { get; set; }//状态（删除）

    }
}
