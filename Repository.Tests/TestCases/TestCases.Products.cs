using System.Collections.Generic;
using DAL;
using DAL.Specifications;
using NUnit.Framework;
using ProductDb.DataClasses;

namespace Repository.Tests.TestCases.Products
{
    [TestFixture]
    public static class TestCasesProducts
    {
        public static IEnumerable<Product> SuccessCreateProductCases()
        {
            yield return new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "New"};
            yield return new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "New 2"};
            yield return new Product { ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "New 3"};
        }
        
        public static IEnumerable<Product> FailCreateProductCases()
        {
            yield return null;
            yield return new Product { Id = 1 ,ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "New"};
        }
        
        public static IEnumerable<Product> SuccessUpdateProductCases()
        {
            yield return new Product { Id = 1, Name = "Changed" };
            yield return new Product { Id = 2, Name = "Changed" };
            yield return new Product { Id = 3, Name = "Changed" };
        }

        public static IEnumerable<Product> FailUpdateProductCases()
        {
            yield return null;
            yield return new Product { Id = 99 };
            yield return new Product();
        }
        
        public static IEnumerable<int> SuccessRemoveProductCases()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
        
        public static IEnumerable<int> FailRemoveProductCases()
        {
            yield return -1;
            yield return 99;
            yield return 0;
        }


        

        public static IEnumerable<(ProductFilterSpecification, int)> ProductFilterSpecificationCases()
        {
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 2, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 3, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { TypeId = 1, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { TypeId = 2, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { TypeId = 3, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { CategoryId = 1, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { CategoryId = 2, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { CategoryId = 3, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { Search = "Product", PageSize = 0}), 12);
            yield return (new ProductFilterSpecification(new ProductParams { Search = "Product" }), 6);
            yield return (new ProductFilterSpecification(new ProductParams { Search = "Dummy" }), 0);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, TypeId = 1, CategoryId = 1, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, TypeId = 2, CategoryId = 1, PageSize = 0}), 0);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 2, TypeId = 2, CategoryId = 2, PageSize = 0}), 4);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 2, TypeId = 3, CategoryId = 2, PageSize = 0}), 0);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, TypeId = 1, CategoryId = 1, Search = "Product", PageSize = 0 }), 4);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, TypeId = 1, CategoryId = 1, Search = "Product 1", PageSize = 0 }), 2);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, TypeId = 1, CategoryId = 1, Search = "Product 2", PageSize = 0 }), 0);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 1, TypeId = 1, CategoryId = 1, Search = "10", PageSize = 0 }), 1);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 2, TypeId = 1, CategoryId = 1, Search = "10", PageSize = 0 }), 0);
            yield return (new ProductFilterSpecification(new ProductParams { BrandId = 3, TypeId = 3, CategoryId = 3, Search = "12", PageSize = 0 }), 1);
        }
    }
}