using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Repository.Products;
using Microsoft.EntityFrameworkCore;
using ProductDb.DataClasses;

namespace DAL.Repository.ProductTypes
{
    public static class RepositoryProductTypes
    {
        public static async Task<IReadOnlyList<ProductType>> GetProductTypes(this Repo repo)
        {
            return await repo.ProductContext.ProductTypes.ToListAsync();
        } 

        public static async Task<ProductType> GetProductTypeById(this Repo repo,int id)
        {
            return await repo.ProductContext.ProductTypes
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(pt => pt.Id == id);
        }

        public static async Task<bool> CreateProductType(this Repo repo, ProductType productType)
        {
            if (productType is null)
                return false;

            if (productType.Id is not 0)
                return false;

            await repo.ProductContext.ProductTypes.AddAsync(productType);
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }

        public static async Task<bool> UpdateProductType(this Repo repo, ProductType productType)
        {
            if (productType is null)
                return false;

            var typeToUpdate = await repo.GetProductTypeById(productType.Id);
            if (typeToUpdate is null)
                return false;

            var entry = repo.ProductContext.Entry(productType);
            entry.State = EntityState.Modified;
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }

        public static async Task<bool> DeleteProductType(this Repo repo, int id)
        {
            var typeToDelete = await repo.GetProductTypeById(id);
            if (typeToDelete is null)
                return false;
            
            var products = await repo.GetAllProducts();
            foreach (var product in products)
            {
                if (product.ProductTypeId == id)
                    product.ProductTypeId = null;
                    repo.ProductContext.Entry(product.ProductType).State = EntityState.Detached;
            }

            repo.ProductContext.ProductTypes.Remove(typeToDelete);
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}