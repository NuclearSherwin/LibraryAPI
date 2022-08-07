using System;
using System.Collections.Generic;
using Library.Entities;

namespace Library.Repositories
{
    public interface IInMemCategoriesRepository
    {
        IEnumerable<Category> getAll();
        Category GetCategory(Guid id);
    }
}