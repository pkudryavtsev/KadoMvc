using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.Repository.Products;
using DAL.Repository.ProductTypes;
using NUnit.Framework;
using ProductDb.DataClasses;
using Repository.Tests;
using Repository.Tests.TestCases.ProductTypes;

namespace Repository.ProductTypes.Tests
{
    [TestFixture]
    public class RepositoryProductTypesTests
    {
        [SetUp]
        public void Setup()
        {
            TestHelper.SeedTestDb();
        }

        [Test]
        public async Task Products_GetProductTypes_ReturnsListOfTypes()
        {
            using (var context =  TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var productTypes = await repository.GetProductTypes();

                Assert.NotZero(productTypes.Count);
                Assert.IsInstanceOf<IReadOnlyList<ProductType>>(productTypes);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductTypes), nameof(TestCasesProductTypes.SuccessCreateTypeCases))]
        public async Task ProductTypes_CreateProductType_ReturnsTrueIfSuccess(ProductType Type)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateProductType(Type);

                Assert.IsTrue(isSuccess);
            }
        }
        

        [Test]
        [TestCaseSource(typeof(TestCasesProductTypes), nameof(TestCasesProductTypes.FailCreateTypeCases))]
        public async Task ProductTypes_CreateProductType_ReturnsFalseIfFail(ProductType Type)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateProductType(Type);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductTypes), nameof(TestCasesProductTypes.SuccessUpdateTypeCases))]
        public async Task ProductTypes_UpdateProductType_ReturnsTrueIfSuccess(ProductType Type)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateProductType(Type);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductTypes), nameof(TestCasesProductTypes.FailUpdateTypeCases))]
        public async Task ProductTypes_UpdateProductType_ReturnsFalseIfFail(ProductType Type)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateProductType(Type);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductTypes), nameof(TestCasesProductTypes.SuccessRemoveTypeCases))]
        public async Task ProductTypes_RemoveProductType_ReturnsTrueIfSuccess(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteProductType(id);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProductTypes), nameof(TestCasesProductTypes.FailRemoveTypeCases))]
        public async Task ProductTypes_RemoveProductType_ReturnsFalseIfFail(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteProductType(id);

                Assert.IsFalse(isSuccess);
            }
        }
    }
}