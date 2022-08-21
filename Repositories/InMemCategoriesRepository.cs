using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Entities;
using Library.Repositories;

namespace Library.Repositories
{
    public class InMemCategoriesRepository : IInMemCategoriesRepository
    {
        private readonly List<Category> _categories = new() {
            new Category { Id = Guid.NewGuid(), Name = "Universe", Description = "Galaxy, Aliens, Things, Black hole", CreateDate = DateTimeOffset.UtcNow },
            new Category { Id = Guid.NewGuid(), Name = "Animation", Description = "Animation, draw, cosmic", CreateDate = DateTimeOffset.UtcNow },
            new Category { Id = Guid.NewGuid(), Name = "Music", Description = "Songs, lyrics, MV, Singer", CreateDate = DateTimeOffset.UtcNow },
        };

        public async Task CreateCategoryAsync(Category category)
        {
            _categories.Add(category);
            await Task.CompletedTask;
        }

        // GET ALL
        public async Task<IEnumerable<Category>> getAllAsync()
        {
            return await Task.FromResult(_categories);
        }


        // GET BY ID
        public async Task<Category> GetCategoryAsync(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var categoryToUpdate = _categories.FindIndex(c => c.Id == category.Id);
            _categories[categoryToUpdate] = category;
            await Task.CompletedTask;
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var index = _categories.FindIndex(c => c.Id == id);
            _categories.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}