using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductDb;
using ProductDb.DataClasses;
using ProductDb.DataClasses.Enums;

namespace Repository.Tests
{
    public static class TestHelper
    {
        public static ProductDbContext CreateContext()
        {
            string ConnStr = "PresentBox_Test";
            DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
			DirectoryInfo temp = info.Parent.Parent.Parent.Parent;
			string CurDir = Path.Combine(temp.ToString(), "API");
			var configuration =  new ConfigurationBuilder().SetBasePath(CurDir).AddJsonFile("appsettings.json").Build();
			var builder = new DbContextOptionsBuilder<ProductDbContext>();
			string connectionString = configuration.GetConnectionString(ConnStr);
            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging();
			return new ProductDbContext(builder.Options) {Configuration = configuration};
        }

        public static void SeedTestDb()
        {
            using (var context = CreateContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var productBrands = new List<ProductBrand> {
                    new ProductBrand { Name = "Product brand 1"},
                    new ProductBrand { Name = "Product brand 2"},
                    new ProductBrand { Name = "Product brand 3"},
                };
                context.ProductBrands.AddRange(productBrands);
                context.SaveChanges();

                var productTypes = new List<ProductType> {
                    new ProductType { Name = "Product type 1"},
                    new ProductType { Name = "Product type 2"},
                    new ProductType { Name = "Product type 3"},
                };
                context.ProductTypes.AddRange(productTypes);
                context.SaveChanges();

                var categories = new List<Category> {
                    new Category { Name = "Category 1"},
                    new Category { Name = "Category 2"},
                    new Category { Name = "Category 3"},
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                var boxes = new List<Box> {
                    new Box { Name = "Box 1", Size = BoxSize.Small, Color = BoxColor.Red},
                    new Box { Name = "Box 2", Size = BoxSize.Medium, Color = BoxColor.Black},
                    new Box { Name = "Box 3", Size = BoxSize.Large, Color = BoxColor.Green},
                    new Box { Name = "Box 4", Size = BoxSize.Small, Color = BoxColor.Blue},
                };
                context.Boxes.AddRange(boxes);
                context.SaveChanges();

                var products = new List<Product> {
                    new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 1"}, 
                    new Product { ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2,  Name = "Product 2"}, 
                    new Product { ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 3"}, 
                    new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 4"}, 
                    new Product { ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 5"}, 
                    new Product { ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 6"}, 
                    new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 7"}, 
                    new Product { ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 8"}, 
                    new Product { ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 9"}, 
                    new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 10"}, 
                    new Product { ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 11"}, 
                    new Product { ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 12"},
                };
                context.Products.AddRange(products);
                context.SaveChanges();

                var boxProducts = new List<BoxProduct> {
                    new BoxProduct { BoxId = 1, ProductId = 1},
                    new BoxProduct { BoxId = 1, ProductId = 2},
                    new BoxProduct { BoxId = 1, ProductId = 3},
                    new BoxProduct { BoxId = 2, ProductId = 4},
                    new BoxProduct { BoxId = 2, ProductId = 5},
                    new BoxProduct { BoxId = 2, ProductId = 6},
                    new BoxProduct { BoxId = 2, ProductId = 7},
                    new BoxProduct { BoxId = 3, ProductId = 8},
                    new BoxProduct { BoxId = 3, ProductId = 9},
                    new BoxProduct { BoxId = 3, ProductId = 10},
                    new BoxProduct { BoxId = 4, ProductId = 1},
                    new BoxProduct { BoxId = 4, ProductId = 3},
                    new BoxProduct { BoxId = 4, ProductId = 12},
                };
                context.BoxProducts.AddRange(boxProducts);
                context.SaveChanges();   
            };
        }

        public static async Task<Box> GetLastBox(this Repo repo)
        {
            using (var context = CreateContext())
            {
                return await context.Boxes.LastAsync();
            }
        }
    }
}