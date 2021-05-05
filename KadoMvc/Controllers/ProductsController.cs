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
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Gets all products with specified parameters
        /// </summary>
        /// <param name="productParams">Product params binded from query string</param>
        /// <returns>Returns list of products</returns>
        /// <response code="200">Successfully retrieves products</response>
        /// <response code="204">No products were found with specified parameters</response>
        /// <response code="400">Fails to map product parameters</response>
        [HttpGet()]
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery] ProductParams productParams)
        {
            var products = await _productService.GetProductsWithParams(productParams);

            if (products is null)
                return BadRequest();

            if (products.Count is 0)
                return NoContent();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductToCreateDto productToCreate)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.AddProduct(productToCreate);

            if (!isSuccess)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var isSuccess = await _productService.RemoveProduct(id);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product productToUpdate)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.EditProduct(productToUpdate);

            if (!isSuccess)
                return BadRequest();

            return NoContent();
        }
    }
}