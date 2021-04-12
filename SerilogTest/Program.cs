using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace SerilogTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot configuration = new
                ConfigurationBuilder().AddJsonFile("appsettings.json",
                optional: false, reloadOnChange: true).Build();
           Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
                (configuration).CreateLogger();//important
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseSerilog((builder, logger) =>
                    //{
                    //    if (builder.HostingEnvironment.IsDevelopment())
                    //    {
                    //        logger.WriteTo
                    //            .MSSqlServer("Data Source =.;Initial Catalog =serilogTest;user id=sa;password123;Integrated Security = false;MultipleActiveResultSets = true;"
                    //                , new SinkOptions { TableName = "Log", AutoCreateSqlTable = true }
                    //            )
                    //            .MinimumLevel.Information();

                            
                    //    }
                    //    else if(builder.HostingEnvironment.IsProduction())
                    //    {
                    //        logger.WriteTo.Console().MinimumLevel.Information();
                    //    }
                    //});
                });


    }
}
