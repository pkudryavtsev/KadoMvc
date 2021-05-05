using Microsoft.Extensions.Logging;
using ProductDb.DataClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductDb.SeedData
{
    public static class ProductDbContextSeed
    {
        public static async Task SeedAsync(ProductDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var productBrandData = File.ReadAllText("../ProductDb/SeedData/ProductBrandSeed.json");
                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandData);

                    foreach (var brand in productBrands)
                    {
                        context.ProductBrands.Add(brand);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var productTypeData = File.ReadAllText("../ProductDb/SeedData/ProductTypeSeed.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);

                    foreach (var type in productTypes)
                    {
                        context.ProductTypes.Add(type);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.Categories.Any())
                {
                    var categoryData = File.ReadAllText("../ProductDb/SeedData/CategorySeed.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    foreach (var category in categories)
                    {
                        context.Categories.Add(category);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Boxes.Any())
                {
                    var boxesData = File.ReadAllText("../ProductDb/SeedData/BoxDataSeed.json");
                    var boxes = JsonSerializer.Deserialize<List<Box>>(boxesData);

                    foreach (var box in boxes)
                    {
                        context.Boxes.Add(box);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../ProductDb/SeedData/ProductDataSeed.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.BoxProducts.Any())
                {
                    var jsonData = File.ReadAllText("../ProductDb/SeedData/BoxToProductSeed.json");
                    var data = JsonSerializer.Deserialize<List<BoxProduct>>(jsonData);

                    foreach (var entry in data)
                    {
                        context.BoxProducts.Add(entry);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProductDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}
