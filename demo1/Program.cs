using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        //Must of the configurations depends heavily on environment variables 
        //so we use this function to help deployers to know if a environment variable is missing:
        static public void require_environment_variable(string name)
        {
            if (Environment.GetEnvironmentVariable(name) == null)
            {
                Console.WriteLine("Missing environment variable: " + name + "");
                Environment.Exit(1);
            }
        }

    }
}
