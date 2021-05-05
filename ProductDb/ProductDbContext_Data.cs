using Microsoft.EntityFrameworkCore;
using ProductDb.DataClasses;

namespace ProductDb
{
    public partial class ProductDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductBrand> ProductBrands { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Box> Boxes { get; set; }
		public DbSet<BoxProduct> BoxProducts { get; set; }
	}
}
