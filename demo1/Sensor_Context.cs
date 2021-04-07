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

/*
    public class Component
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
    }
    */

    public class Sensor_Context : DbContext
    {

        public Sensor_Context()
        {
        }

/*
        public DbSet<Component> components { get; set; }
        public DbSet<Sensor> sensors { get; set; }
        */


        
        //dotnet ef migrations add migration1
        //
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            /*
            Program.require_environment_variable("POSTGRES_HOST");
            Program.require_environment_variable("POSTGRES_PORT");
            Program.require_environment_variable("POSTGRES_USER");
            Program.require_environment_variable("POSTGRES_DB");
            Program.require_environment_variable("POSTGRES_PASSWORD");
            string host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            string port = Environment.GetEnvironmentVariable("POSTGRES_PORT"); //Usually 5432
            string user = Environment.GetEnvironmentVariable("POSTGRES_USER");
            string db = Environment.GetEnvironmentVariable("POSTGRES_DB");
            string pw = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            string s = "Host=" + host + ";Port=" + port + ";Database=" + db + ";Username=" + user + ";Password=" + pw + "";
            Console.WriteLine("Arena: UseNpgsql: " + s);
            options.UseNpgsql(s);
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }

}