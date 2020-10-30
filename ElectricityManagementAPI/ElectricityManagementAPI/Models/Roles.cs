using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Roles
    {
        //角色表
        public int Id { get; set; }
        public int RName { get; set; } //角色名称
        public string RCoding { get; set; } //角色编码
        public string Creator { get; set; } //创建人
        public int ROrganization { get; set; }//所属组织
        public int Permission { get; set; } //权限
        public string Describe { get; set; } //描述
        public int RState { get; set; } //状态
    }
}
