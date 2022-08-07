using System;
using System.Collections.Generic;
using Library.Entities;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IInMemCategoriesRepository _categoriesRepository;

        public CategoriesController(IInMemCategoriesRepository categoriesRepository)
        {
            this._categoriesRepository = categoriesRepository;
        }

        // GET /categories
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            var categories = _categoriesRepository.getAll();
            return categories;
        }

        // GET /categories/{id}
        [HttpGet("{id}")]
        public ActionResult<Category> getCategory(Guid id)
        {
            var category = _categoriesRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
    }
}