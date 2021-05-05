using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductDb.DataClasses;
using Services;
using Services.Dtos;
using DAL;
using System.Linq;
using Services.Dtos.Products;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductBrandsController : ControllerBase
    {
        private readonly ILogger<ProductBrandsController> _logger;
        private readonly ProductService _productService;

        public ProductBrandsController(ILogger<ProductBrandsController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        
        /// <summary>
        /// Gets all product brands
        /// </summary>
        /// <returns>Returns list of product brands</returns>
        /// <response code="200">Successfully retrieves product brands</response>
        [HttpGet()]
        [HttpGet("Get")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productService.GetProductBrands();

            return Ok(productBrands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
        {
            var productBrand = await _productService.GetProductBrandById(id);

            if (productBrand is null)
                return NotFound();

            return Ok(productBrand);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateProductBrand([FromBody]ProductBrandToCreate productBrandToCreate)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.AddProductBrand(productBrandToCreate);

            if (!isSuccess)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProductBrand([FromBody]ProductBrand productBrandToUpdate)
        {
            var isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.EditProductBrand(productBrandToUpdate);

            if (!isSuccess)
                return BadRequest();

            return Redirect("ProductBrands");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProductBrand(int id)
        {
            var isSuccess = await _productService.RemoveProductBrand(id);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }


    }
}