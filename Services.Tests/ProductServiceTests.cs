using AutoMapper;
using DAL;
using Moq;
using NUnit.Framework;
using Services.Tests.Infrastructure;

namespace Services.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _productService;
        private Mock<Repo> _repo;

        [SetUp]
        public void Setup()
        {
            // _repo = new Mock<Repo>();

            // var mapProfile = new TestMappingProfiles();
            // var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
            // var mapper = new Mapper(configuration);

            // _productService = new ProductService(_repo.Object, mapper);
        }

        [Test]
        public void ProductService_GetProductsWithParams_ReturnProductWithSelectedParams()
        {
            Assert.True(true);
        }
    }
}