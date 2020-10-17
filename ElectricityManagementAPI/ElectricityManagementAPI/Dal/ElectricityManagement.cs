using Dapper;
using ElectricityManagementAPI.Helper;
using ElectricityManagementAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            _connectionString = configuration.GetConnectionString("MySqllinking");
        }

        //显示文章
        public async Task<List<inquire>> GetShowAsync()
        {
            using MySqlConnection tion = new MySqlConnection(_connectionString);
            return  (await tion.QueryAsync<inquire>("SELECT * from Article a join Category c on a.CategoryId=c.CID WHERE c.CState=1")).ToList();
        }
    }
}
