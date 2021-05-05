using System.Collections.Generic;
using ProductDb.DataClasses;

namespace Repository.Tests.TestCases.ProductTypes
{
    public static class TestCasesProductTypes
    {
        public static IEnumerable<ProductType> SuccessCreateTypeCases()
        {
            yield return new ProductType { Name = "Type 1" };
            yield return new ProductType { Name = "Type 2" };
            yield return new ProductType { Name = "Type 3" };
        }

        public static IEnumerable<ProductType> FailCreateTypeCases()
        {
            yield return null;
            yield return new ProductType { Id = 1 };
        }

        public static IEnumerable<ProductType> SuccessUpdateTypeCases()
        {
            yield return new ProductType { Id = 1, Name = "Type 1" };
            yield return new ProductType { Id = 2, Name = "Type 2" };
            yield return new ProductType { Id = 3, Name = "Type 3" };
        }

        public static IEnumerable<ProductType> FailUpdateTypeCases()
        {
            yield return null;
            yield return new ProductType { Id = 99 };
            yield return new ProductType();
        }

        public static IEnumerable<int> SuccessRemoveTypeCases()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<int> FailRemoveTypeCases()
        {
            yield return -1;
            yield return 99;
            yield return 0;
        }
    }
}