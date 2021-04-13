using System;
using System.IO;
using System.Net;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Net.WebSockets;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO.Compression;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;

namespace demo1
{

	public class Layout
	{
		public string name { get; set; }
		public int offset { get; set; }
		public int size { get; set; }
	}

	public class Door
	{
		public string name { get; set; }
		public List<Layout> layouts { get; set; }
	}

	public class Demo_Controller : Controller
	{

		public Demo_Controller()
		{
		}


		//https://stackoverflow.com/questions/61104053/how-do-properly-stream-a-video-using-partial-content-ranges-from-azure-blob-stor
		//https://blogs.visigo.com/chriscoulson/easy-handling-of-http-range-requests-in-asp-net/
		//https://stackoverflow.com/questions/48711209/partial-content-in-net-core-mvc-for-video-audio-streaming/48712243
		[HttpGet("/data/{**name}")]
		public IActionResult GetFileDirect(string name)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "data", name);
			Console.WriteLine(path);
			var res = File(System.IO.File.OpenRead(path), "application/octet-stream");
			res.EnableRangeProcessing = true;
			return res;
		}

		[HttpGet("/projects")]
		public async Task<IActionResult> projects()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "data");
			List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
			for (var i = 0; i < dirs.Count; ++i)
			{
				dirs[i] = dirs[i].Substring(dirs[i].LastIndexOf(Path.DirectorySeparatorChar) + 1);
			}
			string s = JsonSerializer.Serialize<List<string>>(dirs);
			return Content(s, "application/json");
		}

		[HttpGet("/doors")]
		public async Task<IActionResult> doors()
		{
			List<Door> doors = new List<Door>();
			string path = Path.Combine(Directory.GetCurrentDirectory(), "data");
			List<string> names = new List<string>(Directory.EnumerateFiles(path, "*.json"));
			for (var i = 0; i < names.Count; ++i)
			{
				Door door = new Door();
				door.name = Path.GetFileNameWithoutExtension(names[i]);
				string content = System.IO.File.ReadAllText(names[i]);
				door.layouts = JsonSerializer.Deserialize<List<Layout>>(content);
				doors.Add(door);
				//Console.WriteLine(names[i]);
			}
			string s = JsonSerializer.Serialize<List<Door>>(doors);
			return Content(s, "application/json");
		}


		[HttpGet("/mqtt/connect")]
		public async Task<IActionResult> mqtt_connect()
		{
			string host = "192.168.1.195";
			int port = 1883;
			var options = new MqttClientOptionsBuilder()
				.WithTcpServer(host, port)
				//.WithCredentials(txtUsername.Text, txtPassword.Text)
				.WithProtocolVersion(MqttProtocolVersion.V311)
				.Build();
			var auth = await Program.mqtt_client.ConnectAsync(options);
			return Content(auth.ResultCode.ToString(), "text/html");
		}


		[HttpGet("/json")]
		public async Task<IActionResult> json()
		{
			string s = JsonSerializer.Serialize<string>("Hello");
			return Content(s, "application/json");
		}


	}
}