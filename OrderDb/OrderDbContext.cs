using Globals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace OrderDb
{
    public partial class OrderDbContext : DbContext
    {
		public readonly String schemaName = "Ords";

		public String ConnectionString = "";
		public IConfigurationRoot Configuration { get; set; }

		public OrderDbContext(DbContextOptions<OrderDbContext> options)
			: base(options)
		{

		}

		public OrderDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			String ConnStr = "";
			if (Configuration == null)
			{
				ConnStr = Global.GetConnectionStringName();

				Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			}
			else
			{
				ConnStr = "PresentBox_Test";
			}

			optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
		}



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema(schemaName);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
		}
	}
}
