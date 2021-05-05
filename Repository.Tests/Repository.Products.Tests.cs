using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Repository.ProductBrands;
using DAL.Repository.Products;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using ProductDb;
using ProductDb.DataClasses;
using Repository.Tests.TestCases.Products;

namespace Repository.Tests
{
    public class RepositoryProductsTests
    {
        [SetUp]
        public void Setup()
        {
            TestHelper.SeedTestDb();
        }     

        [Test]
        public void DatabaseIsSeeded()
        {
            using (var context = TestHelper.CreateContext())
            {
                Assert.True(context.ProductBrands.Any());
                Assert.True(context.ProductTypes.Any());
                Assert.True(context.Categories.Any());
                Assert.True(context.Boxes.Any());
                Assert.True(context.Products.Any());
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.ProductFilterSpecificationCases))]
        public async Task Products_GetProductsWithSpecification_ReturnsListOfProducts(ValueTuple<ProductFilterSpecification, int> testParams)
        {
            using (var context =  TestHelper.CreateContext())
            {
                //Arrange
                (ProductFilterSpecification caseSpecification, int expectedCount) = testParams;
                var repository = new Repo(context, null);

                //Act
                var products = await repository.GetProductsWithSpecification(caseSpecification);

                //Assert
                Assert.NotNull(products);
                Assert.IsInstanceOf<List<Product>>(products);
                Assert.AreEqual(expectedCount, products.Count);
            
                foreach(var product in products)
                {
                    if (caseSpecification.Params.BrandId is not null) Assert.AreEqual(product.ProductBrandId, caseSpecification.Params.BrandId);
                    if (caseSpecification.Params.TypeId is not null) Assert.AreEqual(product.ProductTypeId, caseSpecification.Params.TypeId);
                    if (caseSpecification.Params.CategoryId is not null) Assert.AreEqual(product.CategoryId, caseSpecification.Params.CategoryId);
                    if (caseSpecification.Params.Search is not null) Assert.IsTrue(product.Name.ToLower().Contains(caseSpecification.Params.Search));
                    Assert.IsInstanceOf<Product>(product);
                }   
            }
        }

        [Test]
        public async Task Products_GetProductsWithNullSpecification_ReturnsAllProducts()
        {
            using (var context =  TestHelper.CreateContext())
            {
                //Arrange
                var repository = new Repo(context, null);

                //Act
                var products = await repository.GetProductsWithSpecification(null);

                //Assert
                Assert.IsInstanceOf<IReadOnlyList<Product>>(products);
                Assert.AreEqual(products.Count, 12);
            }
        }      

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.SuccessCreateProductCases))]
        public async Task Products_CreateProduct_ReturnsTrueIfSucess(Product product)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateProduct(product);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.FailCreateProductCases))]
        public async Task Products_CreateProduct_ReturnsFalseIfFail(Product product)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateProduct(product);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.SuccessUpdateProductCases))]
        public async Task Products_UpdateProduct_ReturnsTrueIfSuccess(Product product)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateProduct(product);

                Assert.IsTrue(isSuccess);
            }
        }
        

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.FailUpdateProductCases))]
        public async Task Products_UpdateProduct_ReturnsFalseIfFail(Product product)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateProduct(product);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.SuccessRemoveProductCases))]
        public async Task Products_DeleteProduct_ReturnsTrueIfSuccess(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteProduct(id);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesProducts), nameof(TestCasesProducts.FailRemoveProductCases))]
        public async Task Products_RemoveProduct_ReturnsFalseIfFail(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteProduct(id);

                Assert.IsFalse(isSuccess);
            }
        }
    }
}