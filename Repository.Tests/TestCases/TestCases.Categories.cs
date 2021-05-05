using System.Collections.Generic;
using ProductDb.DataClasses;

namespace Repository.Tests.TestCases.Categories
{
    public static class TestCasesCategories
    {
        public static IEnumerable<Category> SuccessCreateCategoryCases()
        {
            yield return new Category { Name = "Category 1" };
            yield return new Category { Name = "Category 2" };
            yield return new Category { Name = "Category 3" };
        }

        public static IEnumerable<Category> FailCreateCategoryCases()
        {
            yield return null;
            yield return new Category { Id = 1 };
        }

        public static IEnumerable<Category> SuccessUpdateCategoryCases()
        {
            yield return new Category { Id = 1, Name = "Category 1" };
            yield return new Category { Id = 2, Name = "Category 2" };
            yield return new Category { Id = 3, Name = "Category 3" };
        }

        public static IEnumerable<Category> FailUpdateCategoryCases()
        {
            yield return null;
            yield return new Category { Id = 99 };
            yield return new Category();
        }

        public static IEnumerable<int> SuccessRemoveCategoryCases()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<int> FailRemoveCategoryCases()
        {
            yield return -1;
            yield return 99;
            yield return 0;
        }
    }
}