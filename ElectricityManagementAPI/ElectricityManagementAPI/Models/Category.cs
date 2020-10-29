using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Category
    {
        
        /// <summary>
        /// 文章分类
        /// </summary>

        public int CID { get; set; }//主键自增

        public string CName { get; set; }//分类名称

        public int Cnumber { get; set; }//文章数量

        public bool CState { get; set; }//当前状态

    }
}
