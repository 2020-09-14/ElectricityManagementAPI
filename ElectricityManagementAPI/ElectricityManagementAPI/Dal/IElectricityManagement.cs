﻿using ElectricityManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace ElectricityManagementAPI.Dal
{
     public interface IElectricityManagement
    {


        Task<List<brand>> BrandAsync();
        Task<List<Commodity>> commoditiesAsync();//显示商品
        Task<List<Commodity>> commodeleteAsync();//回收站的商品
        Task<int> CommDelete(string ids);//删除回收站的商品
        Task< List<inquire>> GetShowAsync();
        Task<int> BrandAddAsync(brand b);
        Task<List<Classify>> Classifies();
        Task<List<Classify>> GetClassifies(int ids);
        Task<int> CommAddAsunc(Commodity b);
        Task<List<Specification>> specAsunc();
        //删除shangp
        Task<int> DelCommAsync(string ids);
        //详情
        Commodity Xq(string ids);
        //上架
        int Sj(string ids);
        //删除评论
        Task<int> EvaluateDel(string ids);

        //分类显示
        Task<List<Classify>> ClassShow();
        //获取订单信息
        int Huan(string ids);
        Task<List<OrderModel>> GetOrdersAsync(int? states);
        //获取订单详情
        Task<List<OrderModel>> GetOrdersDetialAsync(int ids);
        //获取发货
        Task<List<OrderModel>> GetOrdersDeliverAsync();
        //运单
        Task<List<WayBillModel>> GetWayBills();
        //订单取消
        Task<List<OrdeCancelModel>> GetOrdeCancels();
        //修改后添加
        Task<int> UptAdd(OrdeCancelModel c);
        //批删取消原因
        Task<int> DelredeAllAsync(string ids);
        //批删订单原因
        Task<int> DelAllAsync(string ids);
        //编辑
        Task<List<OrdeCancelModel>> GetOrdeEdit(int ids);
        //修改
        Task<int> Uptcancel(OrdeCancelModel cc);
        //添加
        Task<int> Addcancel(OrdeCancelModel cc);
        
        //显示地址
        Task<List<a_address>> GetAddressesAsync();
        //添加网点申请
        Task<int> AddBranchAsync(b_branch model);
        //添加京东申请

        //添加新增地址
        Task<int> AddAddressAsync(a_address model);
        //详情显示包裹中心
        Task<List<p_package>> DetailspackageAsync(int id);

        //显示角色信息
        Task<List<Roles>> ShowRolesAsync(string RName, string RCreator);
        //添加角色信息
        Task<int> AddRolesAsync(Roles r);
        //删除角色信息
        Task<int> DelRolesAsync(string ids);
        //修改角色信息
        Task<int> UptRolesAsync(Roles r);
        //反填组织信息
        Task<List<Roles>> FanRolesAsync(int ids);

        //显示功能信息
        Task<List<Function>> ShowFunctionAsync(string FName,string FCoding);
        //添加功能信息
        Task<int> AddFunctionAsync(Function f);
        //删除功能信息
        Task<int> DelFunctionAsync(string ids);
        //修改功能信息
        Task<int> UptFunctionAsync(Function f);
        //反填组织信息
        Task<List<Function>> FanFunctionAsync(int ids);

        //显示组织信息
        Task<List<Tissue>> ShowTissueAsync(string TLinkman,string TName);
        //添加组织信息
        Task<int> AddTissueAsync(Tissue t);
        //删除组织信息
        Task<int> DelTissueAsync(string ids);
        //修改组织信息
        Task<int> UptTissueAsync(Tissue t);
        //反填组织信息
        Task<List<Tissue>> FanTissueAsync(int ids);

        //绑定下拉显示部门
        Task<List<Department>> BindDepartmentAsync();
        //显示快递公司表
        Task<List<e_experssage>> GetExperssagesAsync(string EName,string Eofficial);

        //显示包裹中心
        Task<List<p_package>> GetPackagesAsync(string Pstate, string EName, string Podd, string Pordernumber, string Panomaly);
        //详情页（快递公司）
        Task<List<e_experssage>> DetailsExperssagesAsync(int id);
        //修改（设为收货地址）
        Task<int> UpdAddressAsync(int id);
        //添加网点

        //添加京东

        //处理异常(包裹中心)
        Task<int> AddPackagesAsync(p_package p);
        //删除地址
        Task<int> DelAddressesAsync(int id);
        //添加地址
        Task<int> AddAddressesAsync(a_address a);
        //反填地址
        Task<List<a_address>> FandAddressAsync(int id);
        //更新地址
        Task<int> UptAddressAsync(a_address a);
        //详情页（包裹中心）
        Task<List<p_package>> DetailsPackageAsync(int id);

        //商品评论
        Task<List<Evaluate>> EvaluatesAsync();
        //规格显示
        Task<List<Specification>> Specifications();
        Task<int> SpDel(string ids);//规格删除
        Task<int> SpAdd(Specification s);//规格添加
        Task<int> SpUpt(Specification s);//规格修改
        Specification SpFt(string ids);//反填规格
        //批量发货
        Task<int> GetVAsync(string WayBiilNumber, string WayBillOrderId, string WayBillExpress);
        //退货列表
        Task<List<SalesModel>> GetSales();
        //详情
        Task<List<SalesModel>> DetailsSales(int id);
    }
}
