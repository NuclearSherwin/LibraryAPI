using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET ALL
        public IEnumerable<Category> getAll()
        {
            return _categories;
        }


        // GET BY ID
        public Category GetCategory(Guid id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }
    }
}