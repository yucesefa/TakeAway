using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.ProductDtos;
using TakeAway.Catalog.Services.ProductServices;

namespace TakeAway.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _categoryService;

        public ProductController(IProductService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _categoryService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _categoryService.CreateProductAsync(createProductDto);
            return Ok("Ürün Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _categoryService.DeleteProductAsyc(id);
            return Ok("Ürün Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var values = await _categoryService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _categoryService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");
        }
    }
}
