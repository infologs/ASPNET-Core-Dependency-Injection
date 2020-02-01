using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyFirstCoreWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseIIS()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseWebRoot("MyCustomFolder")
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();

            CreateHostBuilder(args).Build().Run();
        }

        //Extention methods
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel();
                    webBuilder.UseWebRoot("MyCustomFolder");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
