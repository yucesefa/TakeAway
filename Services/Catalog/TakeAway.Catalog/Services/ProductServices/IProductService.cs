using TakeAway.Catalog.Dtos.ProductDtos;

namespace TakeAway.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsyc(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
