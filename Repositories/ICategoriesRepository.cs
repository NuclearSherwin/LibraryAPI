using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Entities;

namespace Library.Repositories
{
    public interface IInMemCategoriesRepository
    {
        Task<IEnumerable<Category>> getAllAsync();
        Task<Category> GetCategoryAsync(Guid id);
        Task CreateCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}