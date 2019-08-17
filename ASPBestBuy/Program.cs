using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ASPBestBuy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string jsonData = File.ReadAllText("appSettings.Debug.json");
            SaleRepo.ConnectionString = JObject.Parse(jsonData)["ConnectionString"].ToString();
            EmployeeRepo.ConnectionString = JObject.Parse(jsonData)["ConnectionString"].ToString();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
