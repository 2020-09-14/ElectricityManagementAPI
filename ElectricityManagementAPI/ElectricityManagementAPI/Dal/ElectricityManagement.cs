using Dapper;

using ElectricityManagementAPI;
using ElectricityManagementAPI.Models;

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
        public ElectricityManagement(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> DelAllAsync(string ids)
        {
            string sql = $"delete from `order` where OrderId in ({ids})";
            using (MySqlConnection conn=new MySqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync(sql);
            }
        }
        
            
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
        public async Task<List<OrderModel>> GetOrdersDeliverAsync()
        {

            string sql = $"select * from `order`  join goods  on OrderGoodsId=goodsId join buyerinfo on OrderBuyerId=BuyerInfold join buyerrelation on BuyerInfoPlace=BuyerRelationInfo join buyeraddress on BuyerRelationAddress = BuyerAddressId where 1 =1 and  buyerrelation.BuyerRelationState = 1  and Orderstate = 3 ";
          
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                return (await conn.QueryAsync<OrderModel>(sql)).ToList();
            }

            

        }

        //显示文章
        public async Task<List<inquire>> GetShowAsync()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return  (await tion.QueryAsync<inquire>("SELECT * from Article a join Category c on a.CategoryId=c.CID WHERE c.CState=1")).ToList();
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

    }
}
