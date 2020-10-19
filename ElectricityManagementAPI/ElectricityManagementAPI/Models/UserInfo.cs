using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class UserInfo
    {
        //用户表
        public int UId { get; set; }
        public string UserName { get; set; }//用户名
        public string Password { get; set; }//密码
        public string Phone { get; set; }//手机号
    }
}
