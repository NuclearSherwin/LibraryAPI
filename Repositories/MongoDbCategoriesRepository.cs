using System;
using System.Collections.Generic;
using Library.Entities;
using MongoDB.Driver;

namespace Library.Repositories
{
    public class MongoDbCategoriesRepository : IInMemCategoriesRepository
    {
        private const string databaseName = "Library";
        private const string collectionName = "Categories";
        // private readonly IMongoCollection<Category> _categoriesCollection;
        private readonly IMongoCollection<Category> _categoriesCollection;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Category> getAll()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}