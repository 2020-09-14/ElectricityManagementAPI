using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Search
    {
        //文章评论

        //用户表

        public int Uid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// 评论表
        /// </summary>

        public int MId { get; set; }//主键自增

        public string Portrait { get; set; }//用户头像

        public string Content { get; set; }//评论内容

        public int Thumb { get; set; }//点赞数量

        public DateTime Contime { get; set; }//评论时间

        public bool State { get; set; }//用户状态
    }
}
