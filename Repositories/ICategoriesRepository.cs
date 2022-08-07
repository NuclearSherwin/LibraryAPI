using System;
using System.Collections.Generic;
using Library.Entities;

namespace Library.Repositories
{
    public interface IInMemCategoriesRepository
    {
        IEnumerable<Category> getAll();
        Category GetCategory(Guid id);
        void CreateCategory(Category category);

        void UpdateCategory(Category category);
        void DeleteCategory(Guid id);
    }
}