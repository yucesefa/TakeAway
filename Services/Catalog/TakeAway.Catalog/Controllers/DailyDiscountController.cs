using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.DailyDiscountDtos;
using TakeAway.Catalog.Services.DailyDiscountServices;

namespace TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyDiscountController : ControllerBase
    {
        private readonly IDailyDiscountService _categoryService;

        public DailyDiscountController(IDailyDiscountService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> DailyDiscountList()
        {
            var values = await _categoryService.GetAllDailyDiscountAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDailyDiscount(CreateDailyDiscountDto createDailyDiscountDto)
        {
            await _categoryService.CreateDailyDiscountAsync(createDailyDiscountDto);
            return Ok("İndirim Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDailyDiscount(string id)
        {
            await _categoryService.DeleteDailyDiscountAsyc(id);
            return Ok("İndirim Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyDiscount(string id)
        {
            var values = await _categoryService.GetByIdDailyDiscountAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDailyDiscount(UpdateDailyDiscountDto updateDailyDiscountDto)
        {
            await _categoryService.UpdateDailyDiscountAsync(updateDailyDiscountDto);
            return Ok("İndirim başarıyla güncellendi");
        }
    }
}
