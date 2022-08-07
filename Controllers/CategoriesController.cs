using System;
using System.Collections.Generic;
using System.Linq;
using Library.Dtos;
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
        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = _categoriesRepository.getAll().Select(c => c.AsDto());
            return categories;
        }

        // GET /categories/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> getCategory(Guid id)
        {
            var category = _categoriesRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category.AsDto();
        }
    }
}