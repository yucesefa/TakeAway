using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.SliderDtos;
using TakeAway.Catalog.Services.SliderServices;

namespace TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _categoryService;

        public SliderController(ISliderService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var values = await _categoryService.GetAllSliderAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _categoryService.CreateSliderAsync(createSliderDto);
            return Ok("Slider Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _categoryService.DeleteSliderAsyc(id);
            return Ok("Slider Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(string id)
        {
            var values = await _categoryService.GetByIdSliderAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _categoryService.UpdateSliderAsync(updateSliderDto);
            return Ok("Slider başarıyla güncellendi");
        }
    }
}
