using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Repository.Products;
using Microsoft.EntityFrameworkCore;
using ProductDb.DataClasses;

namespace DAL.Repository.Categories
{
    public static class RepositoryCategories
    {
        public static async Task<IReadOnlyList<Category>> GetCategories(this Repo repo)
        {
            return await repo.ProductContext.Categories.ToListAsync();
        } 

        public static async Task<Category> GetCategoryById(this Repo repo,int id)
        {
            return await repo.ProductContext.Categories
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(c => c.Id == id);
        }

        public static async Task<bool> CreateCategory(this Repo repo, Category category)
        {
            if (category is null)
                return false;

            if (category.Id is not 0)
                return false;

            await repo.ProductContext.Categories.AddAsync(category);
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }

        public static async Task<bool> UpdateCategory(this Repo repo, Category category)
        {
            if (category is null)
                return false;

            var typeToUpdate = await repo.GetCategoryById(category.Id);
            if (typeToUpdate is null)
                return false;

            var entry = repo.ProductContext.Entry(category);
            entry.State = EntityState.Modified;
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }

        public static async Task<bool> DeleteCategory(this Repo repo, int id)
        {
            var typeToDelete = await repo.GetCategoryById(id);
            if (typeToDelete is null)
                return false;

            var products = await repo.GetAllProducts();
            foreach (var product in products)
            {
                if (product.CategoryId == id)
                    product.CategoryId = null;
                    repo.ProductContext.Entry(product.Category).State = EntityState.Detached;
            }

            repo.ProductContext.Categories.Remove(typeToDelete);
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }
    }    
}