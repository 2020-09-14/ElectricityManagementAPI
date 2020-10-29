using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    public class Roles
    {
        //角色表
        public int RId { get; set; }
        public string RName { get; set; } //角色名称
        public string RCoding { get; set; } //角色编码
        public string RCreator { get; set; } //创建人
        public int ROrganization { get; set; }//所属组织
        public string RDescribe { get; set; } //描述
        public int RState { get; set; } //状态


        public int DId { get; set; }
        public string DName { get; set; }//部门名称
    }
}
