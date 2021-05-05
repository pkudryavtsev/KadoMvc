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
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ProductService _productService;

        public CategoriesController(ILogger<CategoriesController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Gets all product categories
        /// </summary>
        /// <returns>Returns list of product categories</returns>
        /// <response code="200">Successfully retrieves product categories</response>
        [HttpGet()]
        [HttpGet("Get")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            var categories = await _productService.GetCategories();

            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _productService.GetCategoryById(id);

            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryToCreate categoryToCreate)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.AddCategory(categoryToCreate);

            if (!isSuccess)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateCategory([FromBody] Category categoryToUpdate)
        {
            var isSuccess = false;
            if (ModelState.IsValid)
                isSuccess = await _productService.EditCategory(categoryToUpdate);

            if (!isSuccess)
                return BadRequest();

            return Redirect("Categories");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var isSuccess = await _productService.RemoveCategory(id);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
    }
}
