using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElectricityManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseIIS().UseStartup<Startup>();
        //        });
        //public static void Main(string[] args)
        //{
        //    var configuration=new ConfigurationBinder().
        //    CreateWebHostBuilder(args, configuration).Build().Run();
        //}
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args,IConfiguration configuration)
        //{
        //    return WebHost.CreateDefaultBuilder(args).UseConfiguration(configuration).UseKestrel(opt =>
        //    {
        //        opt.Limits.MinRequestBodyDataRate = null;
        //    }).UseIIS().UseStartup<Startup>();
        //}
    }
}
