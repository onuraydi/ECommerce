using AutoMapper;
using Ecommerce.Catalog.Settings;
using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Entities;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(values);
        }

        public Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            return _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId,values);
        }
    }
}
