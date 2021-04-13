using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.Net;
using System.Net.WebSockets;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//https://www.compose.com/articles/code-first-database-design-with-entity-framework-and-postgresql/


namespace demo1
{

	public class Sensor_Context : DbContext
	{

		public Sensor_Context()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

	}

}