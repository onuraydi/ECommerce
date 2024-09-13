﻿using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using ECommerce.Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace ECommerce.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty); // kullanılan herhangi bir filtre yok
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPricePriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPricePriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument{
                    {"_id",null },
                    {"averagePrice",new BsonDocument("$avg","$ProductPrice") }
                })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var values = result.FirstOrDefault().GetValue("averagePrice",decimal.Zero).AsDecimal;
            return values;
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
