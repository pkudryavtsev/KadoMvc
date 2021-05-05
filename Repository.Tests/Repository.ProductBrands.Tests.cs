using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.Repository.ProductBrands;
using NUnit.Framework;
using ProductDb.DataClasses;
using Repository.Tests;
using Repository.Tests.TestCases.ProductBrands;

namespace Repository.ProductBrands.Tests
{
    [TestFixture]
    public class RepositoryProductBrandsTests
    {
        [SetUp]
        public void Setup()
        {
            TestHelper.SeedTestDb();
        }

        [Test]
        public async Task Products_GetProductBrands_ReturnsListOfBrands()
        {
            using (var context =  TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var productBrands = await repository.GetProductBrands();

                Assert.NotZero(productBrands.Count);
                Assert.IsInstanceOf<IReadOnlyList<ProductBrand>>(productBrands);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductBrands), nameof(TestCasesProductBrands.SuccessCreateBrandCases))]
        public async Task ProductBrands_CreateProductBrand_ReturnsTrueIfSuccess(ProductBrand brand)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateProductBrand(brand);

                Assert.IsTrue(isSuccess);
            }
        }
        

        [Test]
        [TestCaseSource(typeof(TestCasesProductBrands), nameof(TestCasesProductBrands.FailCreateBrandCases))]
        public async Task ProductBrands_CreateProductBrand_ReturnsFalseIfFail(ProductBrand brand)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateProductBrand(brand);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductBrands), nameof(TestCasesProductBrands.SuccessUpdateBrandCases))]
        public async Task ProductBrands_UpdateProductBrand_ReturnsTrueIfSuccess(ProductBrand brand)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateProductBrand(brand);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductBrands), nameof(TestCasesProductBrands.FailUpdateBrandCases))]
        public async Task ProductBrands_UpdateProductBrand_ReturnsFalseIfFail(ProductBrand brand)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateProductBrand(brand);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductBrands), nameof(TestCasesProductBrands.SuccessRemoveBrandCases))]
        public async Task ProductBrands_RemoveProductBrand_ReturnsTrueIfSuccess(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteProductBrand(id);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductBrands), nameof(TestCasesProductBrands.FailRemoveBrandCases))]
        public async Task ProductBrands_RemoveProductBrand_ReturnsFalseIfFail(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteProductBrand(id);

                Assert.IsFalse(isSuccess);
            }
        }

    }
}