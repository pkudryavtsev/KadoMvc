using System.Collections.Generic;
using ProductDb.DataClasses;

namespace Repository.Tests.TestCases.ProductBrands
{
    public static class TestCasesProductBrands
    {
        public static IEnumerable<ProductBrand> SuccessCreateBrandCases()
        {
            yield return new ProductBrand { Name = "Brand 1" };
            yield return new ProductBrand { Name = "Brand 2" };
            yield return new ProductBrand { Name = "Brand 3" };
        }

        public static IEnumerable<ProductBrand> FailCreateBrandCases()
        {
            yield return null;
            yield return new ProductBrand { Id = 1 };
        }

        public static IEnumerable<ProductBrand> SuccessUpdateBrandCases()
        {
            yield return new ProductBrand { Id = 1, Name = "Brand 1" };
            yield return new ProductBrand { Id = 2, Name = "Brand 2" };
            yield return new ProductBrand { Id = 3, Name = "Brand 3" };
        }

        public static IEnumerable<ProductBrand> FailUpdateBrandCases()
        {
            yield return null;
            yield return new ProductBrand { Id = 99 };
            yield return new ProductBrand();
        }

        public static IEnumerable<int> SuccessRemoveBrandCases()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<int> FailRemoveBrandCases()
        {
            yield return -1;
            yield return 99;
            yield return 0;
        }
    }
}