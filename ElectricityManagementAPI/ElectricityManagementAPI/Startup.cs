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

            
           
        
            //���ÿ���������������Դ��

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

         
            app.UseFileServer(new FileServerOptions()//ֱ�ӿ����ļ�Ŀ¼���ʺ��ļ�����
            {
                EnableDirectoryBrowsing = true,//����Ŀ¼����

              //  FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"C:\Users\HP\Desktop\�½��ļ���\ElectricityManagementAPI\ElectricityManagementAPI\Images\"),




                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"C:\Users\T\Desktop\ElectricityManagementAPI\ElectricityManagementAPI\ElectricityManagementAPI\Images\"),

               // FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"E:\��һ��Ŀ\API1\ElectricityManagementAPI\ElectricityManagementAPI\Images"),

                //FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"D:\���̺�̨API\ElectricityManagementAPI\ElectricityManagementAPI\Images"),


                
 


                //FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"C:\Users\guisu\Desktop\����\�½��ļ���\ElectricityManagementAPI\ElectricityManagementAPI\Images\"),


                RequestPath = new PathString("/Images")
            });

           


        }
    }
}
