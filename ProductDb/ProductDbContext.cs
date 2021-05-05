using Globals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProductDb.DataClasses;
using System;
using System.IO;

namespace ProductDb
{
    public partial class ProductDbContext : DbContext
	{
		public readonly String schemaName = "Prd";

        public String ConnectionString = "";
		public IConfigurationRoot Configuration { get; set; }

		public ProductDbContext(DbContextOptions<ProductDbContext> options)
			: base(options)
		{

		}

		public ProductDbContext()
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
		}

		public ProductDbContext CreateTestContext()
		{
			DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
			DirectoryInfo temp = info.Parent.Parent.Parent.Parent;
			String CurDir = Path.Combine(temp.ToString(), "API");
			String ConnStr = "PresentBox_Test";
			Configuration = new ConfigurationBuilder().SetBasePath(CurDir).AddJsonFile("appsettings.json").Build();
			DbContextOptionsBuilder builder = new DbContextOptionsBuilder<ProductDbContext>();
			String connectionString = Configuration.GetConnectionString(ConnStr);
			this.ConnectionString = connectionString;
			builder.UseSqlServer(connectionString);
			return this;
		}
	}
}
