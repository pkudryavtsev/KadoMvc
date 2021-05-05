using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repository.Products;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using ProductDb.DataClasses;

namespace DAL.Repository.Boxes
{
    public static class Repository_Boxes
    {
        public static async Task<IReadOnlyList<Box>> GetBoxesWithSpecification(this Repo repo, BoxFilterSpecification specification)        
        {
            if (specification is null)
                return await repo.GetAllBoxes();

            var query = repo.ProductContext.Boxes
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.ProductBrand)
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.ProductType)
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.Category)
                                    .Where(specification.Criteria is null? (p => true) : specification.Criteria);

            if (specification.OrderByDescending is not null)
                query = query.OrderByDescending(specification.OrderByDescending);
            else
                query = query.OrderBy(specification.OrderBy);

            IReadOnlyList<Box> boxes;
            if (specification.Take is 0)
                boxes = await query.ToListAsync();
            else
                boxes = await query
                        .Skip(specification.Skip)
                        .Take(specification.Take)
                        .ToListAsync();
            
            return boxes;
        }

        public static async Task<IReadOnlyList<Box>> GetAllBoxes(this Repo repo)        
        {
            return await repo.ProductContext.Boxes
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.ProductBrand)
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.ProductType)
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.Category)
                                    .ToListAsync();
        }


        public static async Task<Box> GetBoxById(this Repo repo, int id)
        {
            return await repo.ProductContext.Boxes.AsNoTracking()
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.ProductBrand)
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.ProductType)
                                    .Include(b => b.BoxProducts)
                                        .ThenInclude(p => p.Product)
                                        .ThenInclude(p => p.Category)
                                    .FirstOrDefaultAsync(b => b.Id == id);
        }

        private static async Task<Box> GetBoxByIdPrivate(this Repo repo, int id)
        {
            return await repo.ProductContext.Boxes
                                        .Include(b => b.BoxProducts)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(b => b.Id == id);
        }

        public static async Task<bool> CreateBox(this Repo repo, Box box)
        {
            if (box is null)
                return false;
            
            if (box.Id is not 0)
                return false;

            await repo.ProductContext.Boxes.AddAsync(box);
            var changes = await repo.ProductContext.SaveChangesAsync();

            return changes > 0;
        } 

        public static async Task<bool> UpdateBox(this Repo repo, Box box)
        {

            if (box is null)
                return false;
            
            var boxToUpdate = await repo.GetBoxByIdPrivate(box.Id);
            if (boxToUpdate is null)
                return false;

            if (box.BoxProducts is null)
            {
                repo.ProductContext.Entry(box).State = EntityState.Modified;
                return await repo.ProductContext.SaveChangesAsync() > 0;
            }

            repo.ProductContext.BoxProducts.RemoveRange(boxToUpdate.BoxProducts);
            repo.ProductContext.SaveChanges();

            repo.ProductContext.Entry(boxToUpdate).State = EntityState.Detached;
            repo.ProductContext.Entry(box).State = EntityState.Modified;
            
            repo.ProductContext.BoxProducts.AddRange(box.BoxProducts);
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }

        public static async Task<bool> DeleteBox(this Repo repo, int id)
        {
            var boxToDelete = await repo.GetBoxByIdPrivate(id);
            if (boxToDelete is null)
                return false;

            repo.ProductContext.Remove(boxToDelete);
            var changes = await repo.ProductContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}