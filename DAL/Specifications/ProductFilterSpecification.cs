using System;
using System.Linq.Expressions;
using ProductDb.DataClasses;

namespace DAL.Specifications
{
    public class ProductFilterSpecification : BaseSpecification<Product>
    {
        public ProductParams Params { get; protected set; }
        
        public ProductFilterSpecification(ProductParams productParams)
        {
            Params = productParams ?? new ProductParams();

            Criteria = ((p) => 
                (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) 
                && (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) 
                && (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)
                && (!productParams.CategoryId.HasValue || p.CategoryId == productParams.CategoryId)
                );

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        OrderBy = (p => p.Price);
                        break;
                    case "priceDesc":
                        OrderByDescending = (p => p.Price);
                        break;
                    default:
                        break;
                }
            }
            else
                OrderBy = (p => p.Name);

            Skip = productParams.PageSize * (productParams.PageIndex - 1);
            Take = productParams.PageSize;
        }
    }
}