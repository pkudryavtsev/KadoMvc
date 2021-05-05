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

namespace KadoMvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypesController : ControllerBase
    {
        private readonly ILogger<ProductTypesController> _logger;
        private readonly ProductService _productService;

        public ProductTypesController(ILogger<ProductTypesController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Gets all product types
        /// </summary>
        /// <returns>Returns list of product types</returns>
        /// <response code="200">Successfully retrieves product types</response>
        [HttpGet()]
        [HttpGet("Get")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productService.GetProductTypes();

            return Ok(productTypes);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductTypeById(int id)
        {
            var productType = await _productService.GetProductTypeById(id);

            if (productType is null)
                return NotFound();

            return Ok(productType);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateProductType([FromBody]ProductTypeToCreate productTypeToCreate)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.AddProductType(productTypeToCreate);

            if (!isSuccess)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProductType([FromBody]ProductType productTypeToUpdate)
        {
            var isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.EditProductType(productTypeToUpdate);

            if (!isSuccess)
                return BadRequest();

            return Redirect("ProductTypes");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProductType(int id)
        {
            var isSuccess = await _productService.RemoveProductType(id);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
    }
}
