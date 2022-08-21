using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Repositories
{
    public class MongoDbCategoriesRepository : IInMemCategoriesRepository
    {
        private const string databaseName = "Library";
        private const string collectionName = "Categories";
        // private readonly IMongoCollection<Category> _categoriesCollection;
        private readonly IMongoCollection<Category> _categoriesCollection;

        private readonly FilterDefinitionBuilder<Category> _filterBuilder = Builders<Category>.Filter;
        public MongoDbCategoriesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _categoriesCollection = database.GetCollection<Category>(collectionName);

        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoriesCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(category => category.Id, id);
            await _categoriesCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Category>> getAllAsync()
        {
            return await _categoriesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(category => category.Id, id);
            return await _categoriesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, category.Id);
            await _categoriesCollection.ReplaceOneAsync(filter, category);
        }
    }
}