using TakeAway.Catalog.Dtos.CategoryDto;

namespace TakeAway.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsyc(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
