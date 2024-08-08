using AutoMapper;
using Ecommerce.Catalog.Settings;
using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Entities;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace ECommerce.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(values); 
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _aboutCollection.Find<About>(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var values = await _aboutCollection.Find<About>(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, values);
        }
    }
}
