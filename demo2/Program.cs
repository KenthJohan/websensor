using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Net;
using System;



using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using MQTTnet.Adapter;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;




namespace demo1
{
	public class Program
	{

		public static IMqttClient mqtt_client { get; set; }


		public static void Main(string[] args)
		{
			mqtt_client = new MqttFactory().CreateMqttClient();
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
