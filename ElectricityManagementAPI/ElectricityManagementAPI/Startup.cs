using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using ElectricityManagementAPI.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


using Microsoft.Extensions.Configuration;

namespace ElectricityManagementAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            
           
        
            //配置跨域处理，允许所有来源：

            services.AddControllers();


            services.AddSingleton<IElectricityManagement,ElectricityManagement>();

            services.AddCors(options =>
           options.AddPolicy("cor",


           p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())

           );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("cor");
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });

         
            app.UseFileServer(new FileServerOptions()//直接开启文件目录访问和文件访问
            {
                EnableDirectoryBrowsing = true,//开启目录访问

              //  FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"C:\Users\HP\Desktop\新建文件夹\ElectricityManagementAPI\ElectricityManagementAPI\Images\"),




                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"C:\Users\T\Desktop\ElectricityManagementAPI\ElectricityManagementAPI\ElectricityManagementAPI\Images\"),

               // FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"E:\大一项目\API1\ElectricityManagementAPI\ElectricityManagementAPI\Images"),

                //FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"D:\电商后台API\ElectricityManagementAPI\ElectricityManagementAPI\Images"),


                
 


                //FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"C:\Users\guisu\Desktop\电商\新建文件夹\ElectricityManagementAPI\ElectricityManagementAPI\Images\"),


                RequestPath = new PathString("/Images")
            });

           


        }
    }
}
