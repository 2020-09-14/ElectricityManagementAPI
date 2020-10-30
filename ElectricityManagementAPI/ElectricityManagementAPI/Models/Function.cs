using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Function
    {
        //功能管理表
        public int Id { get; set; }
        public string FName { get; set; }//功能名称
        public string FCoding { get; set; }//功能编码
        public DateTime FTime { get; set; }//更新时间
        public int FState { get; set; }//状态
    }
}
