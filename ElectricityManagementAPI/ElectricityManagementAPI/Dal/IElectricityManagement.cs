using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricityManagementAPI.Models;

namespace ElectricityManagementAPI.Dal
{
     public interface IElectricityManagement
    {
        Task< List<inquire>> GetShowAsync();
        //包裹中心表
        Task<List<p_package>> GetPackagesAsync();
        //显示快递公司表
        Task<List<e_experssage>> GetExperssagesAsync(string Ephone, string EName);
        //显示地址表
        Task<List<a_address>> GetAddressesAsync();
        //显示运费模板
        Task<List<f_freight>> GetFreightsAsync();
        //添加运费模板
        Task<int> AddFreightAsync(f_freight model);
        //添加网点申请
        Task<int> AddBranchAsync(b_branch model);
        //添加京东申请
        Task<int> AddJingdongAsync(j_jingdong model);
        //添加新增地址
        Task<int> AddAddressAsync(a_address model);
        //(假删)删除地址、逻辑删除
        Task<int> UptAddressAsync(string Id);
        //(假删)删除运费模板、逻辑删除
        Task<int> UptFreightAsync(string Id);
        //详情显示包裹中心
        Task<List<p_package>> DetailspackageAsync(int id);
    }
}
