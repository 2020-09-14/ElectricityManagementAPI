using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Comment
    {

        //评论表

        public int MID { get; set; }//主键自增

        public string Portrait { get; set; }//用户头像

        public string Nickname { get; set; }//用户昵称

        public string Content { get; set; }//评论内容

        public int Thumb { get; set; }//点赞数量

        public DateTime Contime { get; set; }//评论时间

        public bool State { get; set; }//用户状态

    }
}
