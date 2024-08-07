using AutoMapper;
using MongoDB.Driver;
using TakeAway.Catalog.Dtos.DailyDiscountDtos;
using TakeAway.Catalog.Entities;
using TakeAway.Catalog.Settings;

namespace TakeAway.Catalog.Services.DailyDiscountServices
{
    public class DailyDiscountService:IDailyDiscountService
    {
        private readonly IMongoCollection<DailyDiscount> _productCollection;
        private readonly IMapper _mapper;

        public DailyDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<DailyDiscount>(_databaseSettings.DailyDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDailyDiscountAsync(CreateDailyDiscountDto createDailyDiscountDto)
        {
            var value = _mapper.Map<DailyDiscount>(createDailyDiscountDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteDailyDiscountAsyc(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.DailyDiscountId == id);
        }

        public async Task<List<ResultDailyDiscountDto>> GetAllDailyDiscountAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDailyDiscountDto>>(values);
        }

        public async Task<GetByIdDailyDiscountDto> GetByIdDailyDiscountAsync(string id)
        {
            var value = await _productCollection.Find<DailyDiscount>(x => x.DailyDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDailyDiscountDto>(value);
        }

        public async Task UpdateDailyDiscountAsync(UpdateDailyDiscountDto updateDailyDiscountDto)
        {
            var values = _mapper.Map<DailyDiscount>(updateDailyDiscountDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.DailyDiscountId == updateDailyDiscountDto.DailyDiscountId, values);
        }
    }
}
