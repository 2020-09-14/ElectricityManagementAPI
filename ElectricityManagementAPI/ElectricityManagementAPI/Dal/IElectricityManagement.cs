using ElectricityManagementAPI.Models;
using System;
using System.Collections.Generic;
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

        //获取订单信息

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

    }
}
