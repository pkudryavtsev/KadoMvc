// using NUnit.Framework;
// using NUnit;
// using Moq;
// using Repository;
// using System.Collections.Generic;
// using ProductDb.DataClasses;
// using System.Threading.Tasks;
// using AutoMapper;
// using Services.Helpers;
// using Services.Dtos;
// using System;
// using System.Linq;
// using Services.Tests.Infrastructure;

// namespace Services.Tests
// {
//     [TestFixture]
//     public class ProductServiceTests
//     {
//         private Mock<IGenericRepository<Product>> _productRepo;
//         private ProductService _productService;

//         [SetUp]
//         public void Setup() 
//         {
//             _productRepo = new Mock<IGenericRepository<Product>>();

//             _productRepo.Setup(rp => rp.GetAllAsync().Result)
//                 .Returns(new List<Product> {
//                 new Product {Id = 1, ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 1"}, 
//                 new Product {Id = 2, ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 2"}, 
//                 new Product {Id = 3, ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 3"}, 
//                 new Product {Id = 4, ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 4"}, 
//                 new Product {Id = 5, ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 5"}, 
//                 new Product {Id = 6, ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 6"}, 
//                 new Product {Id = 7, ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 7"}, 
//                 new Product {Id = 8, ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 8"}, 
//                 new Product {Id = 9, ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 9"}, 
//                 new Product {Id = 10, ProductBrandId = 1, ProductTypeId = 1, CategoryId = 1, Name = "Product 10"}, 
//                 new Product {Id = 11, ProductBrandId = 2, ProductTypeId = 2, CategoryId = 2, Name = "Product 11"}, 
//                 new Product {Id = 12, ProductBrandId = 3, ProductTypeId = 3, CategoryId = 3, Name = "Product 12"}, 
//             });

//             var mapProfile = new TestMappingProfiles();
//             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
//             var mapper = new Mapper(configuration);

//             _productService = new ProductService(_productRepo.Object, mapper);
//         }


//         [Test]
//         [TestCase(1)]
//         [TestCase(2)]
//         [TestCase(3)]
//         public async Task ProductService_GetProductsWithBrand_ReturnsProductWithSelectedBrand(int brandId)
//         {
//             var result = await _productService.GetProductsWithParams(new ProductParams {BrandId = brandId});

//             Assert.NotNull(result);

//             Assert.AreEqual(4, result.Count);
            
//             foreach(var item in result)
//             {
//                 Assert.AreEqual(item.ProductBrandId, brandId);
//                 Assert.IsInstanceOf(typeof(ProductToReturnDto), item);
//             }            
//         }

//         [Test]
//         [TestCase(1)]
//         [TestCase(2)]
//         [TestCase(3)]
//         public async Task ProductService_GetProductsWithType_ReturnsProductWithSelectedType(int typeId)
//         {
//             var result = await _productService.GetProductsWithParams(new ProductParams {TypeId = typeId});

//             Assert.NotNull(result);

//             Assert.AreEqual(4, result.Count);
            
//             foreach(var item in result)
//             {
//                 Assert.AreEqual(item.ProductTypeId, typeId);
//                 Assert.IsInstanceOf(typeof(ProductToReturnDto), item);
//             }            
//         }
        
//         [Test]
//         [TestCase(1)]
//         [TestCase(2)]
//         [TestCase(3)]
//         public async Task ProductService_GetProductsWithCategory_ReturnsProductWithSelectedCategory(int categoryId)
//         {
//             var result = await _productService.GetProductsWithParams(new ProductParams {CategoryId = categoryId});

//             Assert.NotNull(result);

//             Assert.AreEqual(4, result.Count);
            
//             foreach(var item in result)
//             {
//                 Assert.AreEqual(item.CategoryId, categoryId);
//                 Assert.IsInstanceOf(typeof(ProductToReturnDto), item);
//             }            
//         }

//         [Test]
//         [TestCaseSource(nameof(ProductParamsCases))]
//         public async Task ProductService_GetProductsWithParams_ReturnProductWithSelectedParams(ValueTuple<ProductParams, int> testParams)
//         {
//             (ProductParams productParams, int expectedCount) = testParams;

//             var result = await _productService.GetProductsWithParams(productParams);

//             Assert.NotNull(result);
//             Assert.AreEqual(expectedCount, result.Count);
            

//             foreach(var item in result)
//             {
//                 if (productParams.BrandId is not null) Assert.AreEqual(item.ProductBrandId, productParams.BrandId);
//                 if (productParams.TypeId is not null) Assert.AreEqual(item.ProductTypeId, productParams.TypeId);
//                 if (productParams.CategoryId is not null) Assert.AreEqual(item.CategoryId, productParams.CategoryId);
//                 if (productParams.Search is not null) Assert.IsTrue(item.Name.ToLower().Contains(productParams.Search));
//                 Assert.IsInstanceOf(typeof(ProductToReturnDto), item);
//             }    
//         }

//         static IEnumerable<(ProductParams, int)> ProductParamsCases()
//         {
//             yield return (new ProductParams {BrandId = 1}, 4);
//             yield return (new ProductParams {BrandId = 2}, 4);
//             yield return (new ProductParams {BrandId = 3}, 4);
//             yield return (new ProductParams {TypeId = 1}, 4);
//             yield return (new ProductParams {TypeId = 2}, 4);
//             yield return (new ProductParams {TypeId = 3}, 4);
//             yield return (new ProductParams {CategoryId = 1}, 4);
//             yield return (new ProductParams {CategoryId = 2}, 4);
//             yield return (new ProductParams {CategoryId = 3}, 4);
//             yield return (new ProductParams {Search = "Product"}, 12);
//             yield return (new ProductParams {Search = "Dummy"}, 0);
//             yield return (new ProductParams {BrandId = 1, TypeId = 1, CategoryId = 1}, 4);
//             yield return (new ProductParams {BrandId = 1, TypeId = 2, CategoryId = 1}, 0);
//             yield return (new ProductParams {BrandId = 2, TypeId = 2, CategoryId = 2}, 4);
//             yield return (new ProductParams {BrandId = 2, TypeId = 3, CategoryId = 2}, 0);
//             yield return (new ProductParams {BrandId = 3, TypeId = 3, CategoryId = 3}, 4);
//             yield return (new ProductParams {BrandId = 1, TypeId = 1, CategoryId = 1, Search = "Product"}, 4);
//             yield return (new ProductParams {BrandId = 1, TypeId = 1, CategoryId = 1, Search = "Product 1"}, 2);
//             yield return (new ProductParams {BrandId = 1, TypeId = 1, CategoryId = 1, Search = "Product 2"}, 0);
//             yield return (new ProductParams {BrandId = 1, TypeId = 1, CategoryId = 1, Search = "10"}, 1);
//             yield return (new ProductParams {BrandId = 2, TypeId = 1, CategoryId = 1, Search = "10"}, 0);
//             yield return (new ProductParams {BrandId = 3, TypeId = 3, CategoryId = 3, Search = "12"}, 1);
//         }
//     }
// }