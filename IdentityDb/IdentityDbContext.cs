using Globals;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace IdentityDb
{
	public class IdentityContext : IdentityDbContext<ApplicationUser>
	{
		public readonly string schemaName = "Idt";
		public IConfigurationRoot Configuration { get; set; }

		public IdentityContext(DbContextOptions<IdentityContext> options)
			: base(options)
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

	}
}
