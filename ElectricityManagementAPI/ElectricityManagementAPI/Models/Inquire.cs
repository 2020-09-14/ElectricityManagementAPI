using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class inquire
    {
        //查询表

        //文章表

        public int AID { get; set; } //主键自增

        public string Title { get; set; }//文章标题

        public int CategoryId { get; set; }//与分类表相关联

        public int ANumber { get; set; }//浏览数量

        public int Collect { get; set; }//收藏数量

        public int Transpond { get; set; }//转发数量

        public int Comment { get; set; }//评论数量

        public int Rank { get; set; }//排序

        public string Cover { get; set; }//封面图

        //文章分类

        public int CID { get; set; }//主键自增

        public string CName { get; set; }//分类名称

        public int Cnumber { get; set; }//文章数量

        public bool CState { get; set; }//当前状态


    }
}
