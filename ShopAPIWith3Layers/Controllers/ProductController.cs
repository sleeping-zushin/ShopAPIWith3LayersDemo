using BusinessLayer.IService;
using DataAccessLayer.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPIWith3Layers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductAddVM product)
        {
            try
            {
                await _productService.AddNewProductAsync(product);
                return Ok(new { Message = "Product added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductVM product)
        {
            if (id != product.ProductId)
            {
                return BadRequest(new { Message = "Product ID mismatch." });
            }
            try
            {
                await _productService.UpdateProductAsync(product);
                return Ok(new { Message = "Product updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                bool isDeleted = await _productService.DeleteProductByIdAsync(id);
                if (isDeleted)
                {
                    return Ok(new { Message = "Product deleted successfully." });
                }
                else
                {
                    return NotFound(new { Message = "Product not found." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
