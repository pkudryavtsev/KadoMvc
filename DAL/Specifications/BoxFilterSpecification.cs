using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using ProductDb.DataClasses;

namespace DAL.Specifications
{
    public class BoxFilterSpecification : BaseSpecification<Box>
    {
        public BoxProductParams Params { get; protected set; }

        public BoxFilterSpecification(BoxProductParams productParams)
        {
            Params = productParams;

            Criteria = ((b) => 
                (!Params.Color.HasValue || (int)b.Color == Params.Color) 
                && (!Params.Size.HasValue || (int)b.Size == Params.Size) 
                && (string.IsNullOrEmpty(Params.Search) || b.BoxProducts.Any(e => e.Product.Name.ToLower().Contains(Params.Search.ToLower())))
                && (!Params.BrandId.HasValue || b.BoxProducts.Any(e => e.Product.ProductBrandId == Params.BrandId))
                && (!Params.TypeId.HasValue || b.BoxProducts.Any(e => e.Product.ProductTypeId == Params.TypeId))
                && (!Params.CategoryId.HasValue || b.BoxProducts.Any(e => e.Product.CategoryId == Params.CategoryId))
                );

            Skip = Params.PageSize * (Params.PageIndex - 1);
            Take = Params.PageSize;

            if (!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort)
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
        }

        // private ExpressionStarter<Box> CreateCriteria()
        // {
        //     var predicates = new List<Expression<Func<Box, bool>>>();

        //     if (!string.IsNullOrEmpty(Params.Search))
        //         predicates.Add(box => box.Products.Any(product => product.Name.ToLower().Contains(Params.Search.ToLower())));

        //     if (Params.TypeId != null)
        //         predicates.Add(box => box.Products.Any(product => product.ProductTypeId == Params.TypeId));

        //     if (Params.BrandId != null)
        //         predicates.Add(box => box.Products.Any(product => product.ProductBrandId == Params.BrandId));

        //     if (Params.CategoryId != null)
        //         predicates.Add(box => box.Products.Any(product => product.CategoryId == Params.CategoryId));

        //     var predicate = PredicateBuilder.New<Box>();

        //     predicate = predicates.Aggregate(predicate, (current, pred) => current.And(pred));

        //     return predicate;
        // }
    }
}