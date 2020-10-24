using Dapper;

using ElectricityManagementAPI;
using ElectricityManagementAPI.Models;
using Microsoft.AspNetCore.Components;
using ElectricityManagementAPI.Helper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;

namespace ElectricityManagementAPI.Dal
{
    public class ElectricityManagement : IElectricityManagement
    {

        private readonly string _connectionString;
       
        //大傻春
        public ElectricityManagement(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("Shenwenjie");
            
          
        }
        //品牌添加
        public async Task<int> BrandAddAsync(brand b)
        {
            string sql = $"insert into brand(img,Bname,Corporation,State,CreaTime) VALUES('{b.Img}','{b.Bname}','{b.Corporation}','{1}','{DateTime.Now}')";
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            int i = await tion.ExecuteAsync(sql);
            return  i;


         
        }
        //删除订单
        public async Task<int> DelAllAsync(string ids)
        {
            string sql = $"delete from  `order` where OrderId in ({ids})";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync(sql);
            }
        }
        //删除取消原因
        public async Task<int> DelredeAllAsync(string ids)
        {
            string sql = $"delete from ordecancel where OrdeCancelId in ({ids})";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync(sql);
            }
        }
        //显示订单
        public async  Task<List<OrderModel>> GetOrdersAsync(int? states)
        {
         
          string sql = $"select * from `order`  join goods  on OrderGoodsId=goodsId join buyerinfo on OrderBuyerId=BuyerInfold join buyerrelation on BuyerInfoPlace=BuyerRelationInfo join buyeraddress on BuyerRelationAddress = BuyerAddressId where 1 =1 and  buyerrelation.BuyerRelationState = 1  ";
            if (states!=0)
            {
                sql += $" and Orderstate = { states }";
            }
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<OrderModel>(sql)).ToList();
            }
        }
        //显示未发货
        public async Task<List<OrderModel>> GetOrdersDeliverAsync()
        {
            string sql = $"select * from `order`  join goods  on OrderGoodsId=goodsId join buyerinfo on OrderBuyerId=BuyerInfold join buyerrelation on BuyerInfoPlace=BuyerRelationInfo join buyeraddress on BuyerRelationAddress = BuyerAddressId where 1 =1 and  buyerrelation.BuyerRelationState = 1  and Orderstate = 3 ";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<OrderModel>(sql)).ToList();
            }
        }
        //品牌显示
        public async Task<List<brand>> BrandAsync()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            List<brand> list = (await tion.QueryAsync<brand>("select Brandid,Img,Bname,Corporation,State,CreaTime from brand where State = 1")).ToList();
            return (list);
        }
        //品牌lugo上传
        
        //商品
        public async Task<List<Commodity>> commoditiesAsync()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return (await tion.QueryAsync<Commodity>("SELECT commodity.Cidd,CommodityId,ClassifyId,SCname,Recommend,Bname,commodity.Img,Introduce,Inventory,commodity.State,Price,commodity.CreaTime from commodity JOIN classify ON ClassifyId  = CommodityId  JOIN brand on brand.Brandid = commodity.Bidd WHERE commodity.delstate = '1'")).ToList();
        }
        //分类父级
        public async Task<List<Classify>> Classifies()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return (await tion.QueryAsync<Classify>("select * from Classify WHERE Cidd = 0")).ToList();
        }
        //分类子集
        public async Task<List<Classify>> GetClassifies(int ids)
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return (await tion.QueryAsync<Classify>($"select * from Classify WHERE Cidd = {ids}")).ToList();
        }
        //显示文章
        public async Task<List<inquire>> GetShowAsync()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return  (await tion.QueryAsync<inquire>("SELECT * from Article a join Category c on a.CategoryId=c.CID WHERE c.CState=1")).ToList();

        }
        // 显示快递公司表
        public async Task<List<e_experssage>> GetExperssagesAsync(string EName, string Eofficial)
        {
            string sql = $"SELECT * from e_experssage where 1=1";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                if (!string.IsNullOrEmpty(EName))
                {
                    sql += $" and EName='{EName}'";
                }
                if (!string.IsNullOrEmpty(Eofficial))
                {
                    sql += $" and Eofficial='{Eofficial}'";
                }
                return (await conn.QueryAsync<e_experssage>(sql)).ToList();
            }
        }
        /// <summary>
        /// 商品添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task<int> CommAddAsunc(Commodity b)
        {
            string sql = $"insert into commodity(Recommend,Bidd,Pay,Img,Introduce,Inventory,Cidd,Creatime,SCname,State,Price) values('{b.Recommend}','{b.Bidd}','{b.Pay}','{b.Img}','{b.Introduce}','{b.Inventory}','{b.Cidd}','{DateTime.Now}','{b.SCname}','{1}','{b.Price}')";
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            int i = await tion.ExecuteAsync(sql);
            return i;
        }
        //所有规格
        public async Task<List<Specification>> specAsunc()
        {
            string sql = $"select * from Specification   ";
            using MySqlConnection tion = new MySqlConnection(_connectionString);
           
            return (await tion.QueryAsync<Specification>(sql)).ToList();
        }
        //删除商品
        public async Task<int> DelCommAsync(string ids)
        {
            string sql = $"UPDATE commodity set delstate = 0 WHERE CommodityId in ({ids}) ";
            using MySqlConnection tion = new MySqlConnection(_connectionString);

            return await tion.ExecuteAsync(sql);
           
        }
        //删除回收站的商品
        public async Task<int> CommDelete(string ids)
        {
            string sql = $"delete from commodity WHERE CommodityId in ({ids}) ";
            using MySqlConnection tion = new MySqlConnection(_connectionString);

            return await tion.ExecuteAsync(sql);

        }
        //详情
        public Commodity Xq(string ids)
        {
            string sql = $"SELECT * from commodity where CommodityId = {ids}  ";
            using MySqlConnection tion = new MySqlConnection(_connectionString);

            return  tion.QueryFirstOrDefault<Commodity>(sql);
        }
        //上架
        public int Sj(string ids)
        {
            string sql = $"UPDATE commodity SET State = 3 where CommodityId = {ids}  ";
            using MySqlConnection tion = new MySqlConnection(_connectionString);

            return tion.Execute(sql);
        }
        //回收站的商品
        public async Task<List<Commodity>> commodeleteAsync()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return (await tion.QueryAsync<Commodity>("SELECT commodity.Cidd,CommodityId,ClassifyId,SCname,Recommend,Bname,commodity.Img,Introduce,Inventory,commodity.State,Price,commodity.CreaTime from commodity JOIN classify ON ClassifyId  = CommodityId  JOIN brand on brand.Brandid = commodity.Bidd WHERE commodity.delstate = '0'")).ToList();
        }
        //添加地址
        public async Task<int> AddAddressAsync(a_address a)
        { 
            string sql = $"INSERT into a_address(Abbreviation,Aconsigner,Aphone,Address,Adeltailedaddress,Adeliverypoint,Areceivingpoint,Atime) VALUES('{a.Abbreviation}', '{a.Aconsigner}', '{a.Aphone}', '{a.Address}', '{a.Adeltailedaddress}', {a.Adeliverypoint}, {a.Areceivingpoint}, '{DateTime.Now}')";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                int i = (await conn.ExecuteAsync(sql));
                return i;
            }

        }
        //详情页（快递公司）
        public async Task<List<e_experssage>> DetailsExperssagesAsync(int id)
        {
            string sql = $"SELECT * from e_experssage WHERE Eid={id}";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<e_experssage>(sql)).ToList();
            }
        }
        //显示包裹中心
        public async Task<List<p_package>> GetPackagesAsync(string Pstate, string EName, string Podd, string Pordernumber)
        {
            string sql = $"select * from p_package  p   join e_experssage e ON p.Eid=e.Eid join `order` o on p.Pordernumber=o.OrderId  where  1=1";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                if (!string.IsNullOrEmpty(Pstate))
                {
                    sql += $" and Pstate='{Pstate}'";
                }
                if (!string.IsNullOrEmpty(EName))
                {
                    sql += $" and EName='{EName}'";
                }
                if (!string.IsNullOrEmpty(Podd))
                {
                    sql += $" and Podd='{Podd}'";
                }
                if (!string.IsNullOrEmpty(Pordernumber))
                {
                    sql += $" and Pordernumber like '{Pordernumber}'";
                }
                return (await conn.QueryAsync<p_package>(sql)).ToList();
            }
        }

        //显示地址
        public async Task<List<a_address>> GetAddressesAsync()
        {
            string sql = $"select * from a_address";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<a_address>(sql)).ToList();
            }
        }
        //修改（设为收货地址）
        public async Task<int> UpdAddressAsync(int id)
        {
            string sql = $"UPDATE a_address set Adeliverypoint=Adeliverypoint+1 where Aid={id}";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }

        //添加网点表
        public async Task<int> AddBranchAsync(b_branch b) 
        {
            string sql = $"";
            using (MySqlConnection conn=new MySqlConnection())
            {
                return await conn.ExecuteAsync(sql);
            }
        }

        //添加京东
        public async Task<int> AddJingdongAsync(j_jingdong j)
        {
            string sql = $"INSERT into j_jingdong(Jmerchant,Jidentification,Jtype,Jquantity,Jfirstheavy,Jcountined,Jtime) VALUES ('{j.Jmerchant}','{j.Jidentification}','{j.Jtype}','{j.Jquantity}','{j.Jfirstheavy}','{j.Jcountined}','{DateTime.Now}')";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                int list = (await conn.ExecuteAsync(sql));
                return list;
            }
        }
        //删除地址
        public async Task<int> DelAddressesAsync(int id)
        {
            string sql = $"DELETE from  a_address where Aid={id}";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                int list = (await conn.ExecuteAsync(sql));
                return list;
            }
        }
        //添加地址
        public async Task<int> AddAddressesAsync(a_address a)
        {
            string sql = $"INSERT into a_address(Abbreviation,Aconsigner,Aphone,Address,Adeltailedaddress,Adeliverypoint,Areceivingpoint,Atime) VALUES('{a.Abbreviation}','{a.Aconsigner}','{a.Aphone}','{a.Address}','{a.Adeltailedaddress}',{a.Adeliverypoint},{a.Areceivingpoint},'{DateTime.Now}')";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                int list = (await conn.ExecuteAsync(sql));
                return list;
            }
        }
        //反填地址
        public async Task<List<a_address>> FandAddressAsync(int id)
        {
            string sql = $"SELECT * from a_address where Aid={id}";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<a_address>(sql)).ToList();
            }
        }
        //修改地址
        public async Task<int> UptAddressAsync(a_address a)
        {
            string sql = $"update a_address set Abbreviation='{a.Abbreviation}',Aconsigner='{a.Aconsigner}',Aphone='{a.Aphone}',Address='{a.Address}',Adeltailedaddress='{a.Adeltailedaddress}',Adeliverypoint='{a.Adeliverypoint}',Areceivingpoint='{a.Areceivingpoint}'  where Aid={a.Aid}";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                int list = (await conn.ExecuteAsync(sql));
                return list;
            }
        }
        //详情页（包裹中心）
        public async Task<List<p_package>> DetailsPackageAsync(int id)
        {
            string sql = $"select * from p_package  p   join e_experssage e ON p.Eid=e.Eid join `order` o on p.Pordernumber=o.OrderId where p.Pid={id}";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<p_package>(sql)).ToList();
            }
        }

        //处理异常（包裹中心）
        public async Task<int> AddPackagesAsync(p_package p)
        {
            string sql = $"INSERT into p_package(Pstatus,Pdescribe) VALUE({p.Pstatus},'{p.Pdescribe}')";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }

        //商品评论
        public async Task<List<Evaluate>> EvaluatesAsync()
        {
            string sql = "SELECT * from evaluate e join commodity c on e.Cidd = c.CommodityId  join buyerinfo b on b.BuyerInfold = e.Uidd";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<Evaluate>(sql)).ToList();
            }
        }
        //删除评论（假删）
        public async Task<int> EvaluateDel(string ids)
        {
            string sql = $"UPDATE evaluate set State = 0 where Evaluateid = ({ids})";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }

        //规格显示
        public async Task<List<Specification>> Specifications()
        {
            string sql = "SELECT * from Specification where Steate = 1";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<Specification>(sql)).ToList();
            }
        }
        //删除规格
        public async Task<int> SpDel(string ids)
        {
            string sql = $"delete from Specification  where SpecificationId in {ids}";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //添加规格
        public async Task<int> SpAdd(Specification s)
        {
            string sql = $"INSERT into specification(Sname,Steate,CreaTime,State) VALUES('{s.Sname}','{s.Steate}','{s.CreaTime}','{s.State}')";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //修改规格
        public async Task<int> SpUpt(Specification s)
        {
            string sql = $"UPDATE specification set Sname='{s.Sname}',Steate='{s.Steate}',CreaTime='{s.CreaTime}',State='{s.State}' WHERE SpecificationId = 99";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //反填规格
        public Specification SpFt(string ids)
        {
            string sql = $"SELECT * from Specification where  SpecificationId = {ids}";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return conn.QueryFirstOrDefault<Specification>(sql);
            }
        }
        //批量发货
        public async Task<int> GetVAsync(string WayBiilNumber, string WayBillOrderId, string WayBillExpress)
        {
          
            string sql = $"insert into waybill(WayBiilNumber,WayBillTime,WayBillOrderId,WayBillState,WayBillExpress) values('{WayBillExpress}','{DateTime.Now}','{WayBillOrderId}','{1}','{WayBiilNumber}')";
            string sql1 = $"UPDATE `order` set Orderstate = 4 WHERE OrderId = {WayBillOrderId}";
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.ExecuteAsync(sql1);
                return (await conn.ExecuteAsync(sql));
            }
        }
        //订单详情
        public async Task<List<OrderModel>> GetOrdersDetialAsync(int ids)
        {
            string sql = $"select * from `order`  join goods  on OrderGoodsId=goodsId join buyerinfo on OrderBuyerId=BuyerInfold join buyerrelation on BuyerInfoPlace=BuyerRelationInfo join buyeraddress on BuyerRelationAddress = BuyerAddressId where 1 =1  and  buyerrelation.BuyerRelationState = 1";
            if (ids != 0)
            {
                sql += $" and OrderId = { ids }";
            }
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<OrderModel>(sql)).ToList();
            }
        }
        //运单
        public async Task<List<WayBillModel>> GetWayBills()
        {
            string sql = "select * from waybill join  `order` on waybill.WayBillOrderId=`order`.OrderId  join goods  on OrderGoodsId=goodsId join buyerinfo on OrderBuyerId=BuyerInfold join buyerrelation on BuyerInfoPlace = BuyerRelationInfo join buyeraddress on BuyerRelationAddress = BuyerAddressId where 1 = 1  and buyerrelation.BuyerRelationState = 1";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<WayBillModel>(sql)).ToList();
            }
        }
        //修改后添加
        public async Task<int> UptAdd(OrdeCancelModel c)
        {

            string sql = $"update `order` set Orderstate=8 where OrderId={c.OrdeCancelStateId}";

            string sql1 = $"insert into ordecancel(OrdeCancelStateId,OrdeCancelCause,OrdeCancelInfo) value ('{c.OrdeCancelStateId}','{c.OrdeCancelCause}','{c.OrdeCancelInfo}')";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.ExecuteAsync(sql);
                return (await conn.ExecuteAsync(sql1));
            }
        }
        //获取取消订单
        public async Task<List<OrdeCancelModel>> GetOrdeCancels()
        {
            string sql = $"select * from ordecancel";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
               
                return (await conn.QueryAsync<OrdeCancelModel>(sql)).ToList();
            }
        }
        //反填
        public async Task<List<OrdeCancelModel>> GetOrdeEdit(int ids)
        {
            string sql = $"select * from ordecancel where  OrdeCancelId={ids}";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {

                return (await conn.QueryAsync<OrdeCancelModel>(sql)).ToList();
            }
        }
        //修改
        public async Task<int> Uptcancel(OrdeCancelModel cc)
        {
            string sql = $"update ordecancel set OrdeCancelStateId='{cc.OrdeCancelStateId}',OrdeCancelCause='{cc.OrdeCancelCause}',OrdeCancelInfo='{cc.OrdeCancelInfo}' where OrdeCancelId={cc.OrdeCancelId}";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {

                return await conn.ExecuteAsync(sql);
            }
        }
        //添加
        public async Task<int> Addcancel(OrdeCancelModel cc)
        {
            string sql = $"insert into ordecancel(OrdeCancelStateId,OrdeCancelCause,OrdeCancelInfo) value ('{cc.OrdeCancelStateId}','{cc.OrdeCancelCause}','{cc.OrdeCancelInfo}')";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {

                return await conn.ExecuteAsync(sql);
            }
        }
        //退货显示
        public async Task<List<SalesModel>> GetSales()
        {
            string sql = $"SELECT * from sales s  join   `order` o on s.ReturnSalesId = o.OrderId join goods  g on  o.OrderGoodsId = g.GoodsId ";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<SalesModel>(sql)).ToList();
            }
        }

        public async Task<List<SalesModel>> DetailsSales(int id)
        {
            string sql = $"SELECT* from sales s  join   `order` o on s.ReturnSalesId = o.OrderId join goods  g on  o.OrderGoodsId = g.GoodsId  where s.SalesId={id}";
            using (MySqlConnection conn=new MySqlConnection(sql))
            {
                return (await conn.QueryAsync<SalesModel>(sql)).ToList();
            }
        }
    }
}
