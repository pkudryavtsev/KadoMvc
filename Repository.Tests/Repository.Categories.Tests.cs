using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.Repository.Categories;
using DAL.Repository.Products;
using NUnit.Framework;
using ProductDb.DataClasses;
using Repository.Tests;
using Repository.Tests.TestCases.Categories;

namespace Repository.Categories.Tests
{
    [TestFixture]
    public class RepositoryCategoriesTests
    {
        [SetUp]
        public void Setup()
        {
            TestHelper.SeedTestDb();
        }

        [Test]
        public async Task Products_GetCategories_ReturnsListOfCategories()
        {
            using (var context =  TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var categories = await repository.GetCategories();

                Assert.NotZero(categories.Count);
                Assert.IsInstanceOf<IReadOnlyList<Category>>(categories);
            }
        }


        [Test]
        [TestCaseSource(typeof(TestCasesCategories), nameof(TestCasesCategories.SuccessCreateCategoryCases))]
        public async Task Categories_CreateCategory_ReturnsTrueIfSuccess(Category category)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateCategory(category);

                Assert.IsTrue(isSuccess);
            }
        }
        

        [Test]
        [TestCaseSource(typeof(TestCasesCategories), nameof(TestCasesCategories.FailCreateCategoryCases))]
        public async Task Categories_CreateCategory_ReturnsFalseIfFail(Category category)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateCategory(category);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesCategories), nameof(TestCasesCategories.SuccessUpdateCategoryCases))]
        public async Task Categories_UpdateCategory_ReturnsTrueIfSuccess(Category category)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateCategory(category);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesCategories), nameof(TestCasesCategories.FailUpdateCategoryCases))]
        public async Task Categories_UpdateCategory_ReturnsFalseIfFail(Category category)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateCategory(category);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesCategories), nameof(TestCasesCategories.SuccessRemoveCategoryCases))]
        public async Task Categories_RemoveCategory_ReturnsTrueIfSuccess(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteCategory(id);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesCategories), nameof(TestCasesCategories.FailRemoveCategoryCases))]
        public async Task Categories_RemoveCategory_ReturnsFalseIfFail(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteCategory(id);

                Assert.IsFalse(isSuccess);
            }
        }
    }
}