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


namespace ElectricityManagementAPI.Dal
{
    public class ElectricityManagement : IElectricityManagement
    {

        private readonly string _connectionString;
       
        //大傻春
        public ElectricityManagement(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("MySqlWang");
          
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
        public async Task<int> AddAddressAsync(a_address model)
        {
            string sql = $"insert int a_address values ('{model.Abbreviation}','{model.Aconsigner}','{model.Aphone}','{model.Address}','{model.Adeltailedaddress}','{model.Abbreviation}','{model.Areceivingpoint}',getdate,'{model.Astate}')";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //添加申请网点
        public async Task<int> AddBranchAsync(b_branch model)
        {
            string sql = $"insert into b_branch(Bmerchant,Bcheckout,Btime) values('{model.MBmerchant}','{model.Bcheckout}',now());";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //添加地址模板
        public async Task<int> AddFreightAsync(f_freight model)
        {
            string sql = $"";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //添加京东申请表
        public async Task<int> AddJingdongAsync(j_jingdong model)
        {
            string sql = $"insert into j_jingdong values ('{model.Jmerchant}','{model.Jidentification}','{model.Jtype}','{model.Jquantity}','{model.Jquantity}','{model.Jfirstheavy}','{model.Jcountined}',getdate())";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //删除地址、按照逻辑删除
        public async Task<int> UptAddressAsync(string Id)
        {
            string sql = $"update a_address  SET Astate=Astate+1 where  Aid in {Id};";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        /// 删除运费模板、按照逻辑删除
        public async Task<int> UptFreightAsync(string Id)
        {
            string sql = $"UPDATE f_freight set Fstate=Fstate+1 where Fid in {Id};";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.ExecuteAsync(sql));
            }
        }
        //显示地址表
        public async Task<List<a_address>> GetAddressesAsync()
        {
            //string sql = $"select * from a_address";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<a_address>("select * from a_address")).ToList();
            }
        }
        // 显示快递公司表
        public async Task<List<e_experssage>> GetExperssagesAsync(string Ephone, string EName)
        {
            string sql = $"select * from e_experssage where 1=1";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                //查询手机号
                if (Ephone != null)
                {
                    sql += $" and Ephone='{Ephone}'";
                }
                //查询企业名称
                if (EName != null)
                {
                    sql += $" and EName  liek '%{EName}%'";
                }
                return (await conn.QueryAsync<e_experssage>(sql)).ToList();
            }

        }
        //显示运费模板
        public async Task<List<f_freight>> GetFreightsAsync()
        {
            string sql = $"select * from f_freight";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<f_freight>(sql)).ToList();
            }
        }
        //显示包裹中心
        public async Task<List<p_package>> GetPackagesAsync()
        {
            string sql = $"SELECT * from p_package p join e_experssage  e on p.Eid=e.Eid;";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<p_package>(sql)).ToList();
            }
        }
        //详情显示包裹中心
        public async Task<List<p_package>> DetailspackageAsync(int id)
        {
            string sql = $"SELECT * from p_package p join e_experssage  e on p.Eid=e.Eid where Pid={id}";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<p_package>(sql)).ToList();
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
    }
}
