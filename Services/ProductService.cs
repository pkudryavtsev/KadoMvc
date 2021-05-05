using ProductDb.DataClasses;
using System.Threading.Tasks;
using System.Collections.Generic;
using Services.Dtos;
using AutoMapper;
using Services.Helpers;
using DAL;
using System.Linq;
using DAL.Specifications;
using DAL.Repository.Products;
using DAL.Repository.ProductBrands;
using DAL.Repository.Boxes;
using DAL.Repository.ProductTypes;
using DAL.Repository.Categories;
using Services.Dtos.Products;

namespace Services
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly Repo _repo;
        public ProductService(Repo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region Products
        public async Task<IReadOnlyList<ProductToReturnDto>> GetProductsWithParams(ProductParams productParams)
        {
            var specification = new ProductFilterSpecification(productParams);

            var products = await _repo.GetProductsWithSpecification(specification);

            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        }

        public async Task<ProductToReturnDto> GetProductById(int id)
        {
            var product = await _repo.GetProductById(id);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        public async Task<bool> AddProduct(ProductToCreateDto productToCreate)
        {
            var product = _mapper.Map<ProductToCreateDto, Product>(productToCreate);

            bool isAdded = await _repo.CreateProduct(product);

            return isAdded;
        }

        public Task<bool> EditProduct(Product productToUpdate)
        {
            Task<bool> isEdited = _repo.UpdateProduct(productToUpdate);

            return isEdited;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var isDeleted = await _repo.DeleteProduct(id);

            return isDeleted;
        }
        #endregion

        #region ProductBrands
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var brands = await _repo.GetProductBrands();

            return brands;
        }

        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            var brand = await _repo.GetProductBrandById(id);

            return brand;
        }

        public async Task<bool> AddProductBrand(ProductBrandToCreate productBrandToCreate)
        {
            var productBrand = _mapper.Map<ProductBrandToCreate, ProductBrand>(productBrandToCreate);

            bool isAdded = await _repo.CreateProductBrand(productBrand);

            return isAdded;
        }
        
        public async Task<bool> EditProductBrand(ProductBrand productBrand)
        {
            bool isAdded = await _repo.UpdateProductBrand(productBrand);

            return isAdded;
        }

        public async Task<bool> RemoveProductBrand(int id)
        {
            bool isAdded = await _repo.DeleteProductBrand(id);

            return isAdded;
        }

        #endregion

        #region ProductTypes


        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var types = await _repo.GetProductTypes();

            return types;
        }

        public async Task<ProductType> GetProductTypeById(int id)
        {
            var type = await _repo.GetProductTypeById(id);

            return type;
        }

        public async Task<bool> AddProductType(ProductTypeToCreate productTypeToCreate)
        {
            var productType = _mapper.Map<ProductTypeToCreate, ProductType>(productTypeToCreate);

            bool isAdded = await _repo.CreateProductType(productType);

            return isAdded;
        }

        public async Task<bool> EditProductType(ProductType productType)
        {
            bool isAdded = await _repo.UpdateProductType(productType);

            return isAdded;
        }

        public async Task<bool> RemoveProductType(int id)
        {
            bool isAdded = await _repo.DeleteProductType(id);

            return isAdded;
        }

        #endregion

        #region Categories
        public async Task<IReadOnlyList<Category>> GetCategories()
        {
            var categories = await _repo.GetCategories();

            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var type = await _repo.GetCategoryById(id);

            return type;
        }

        public async Task<bool> AddCategory(CategoryToCreate categoryToCreate)
        {
            var category = _mapper.Map<CategoryToCreate, Category>(categoryToCreate);

            bool isAdded = await _repo.CreateCategory(category);

            return isAdded;
        }

        public async Task<bool> EditCategory(Category category)
        {
            bool isAdded = await _repo.UpdateCategory(category);

            return isAdded;
        }

        public async Task<bool> RemoveCategory(int id)
        {
            bool isAdded = await _repo.DeleteCategory(id);

            return isAdded;
        }
        #endregion
    }
}