using System;
using System.Collections.Generic;
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

        public void CreateCategory(Category category)
        {
            _categoriesCollection.InsertOne(category);
        }

        public void DeleteCategory(Guid id)
        {
            var filter = _filterBuilder.Eq(category => category.Id, id);
            _categoriesCollection.DeleteOne(filter);
        }

        public IEnumerable<Category> getAll()
        {
            return _categoriesCollection.Find(new BsonDocument()).ToList();
        }

        public Category GetCategory(Guid id)
        {
            var filter = _filterBuilder.Eq(category => category.Id, id);
            return _categoriesCollection.Find(filter).FirstOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, category.Id);
            _categoriesCollection.ReplaceOne(filter, category);
        }
    }
}