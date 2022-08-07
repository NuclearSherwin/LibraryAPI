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


        // POST /categories
        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory(CreateCategoryDto categoryDto)
        {
            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                CreateDate = DateTimeOffset.UtcNow
            };

            _categoriesRepository.CreateCategory(category);

            return CreatedAtAction(nameof(getCategory), new { id = category.Id }, category.AsDto());
        }

        // UPDATE /categories/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(Guid id, CategoryDto categoryDto)
        {
            var exitsCategory = _categoriesRepository.GetCategory(id);
            if (exitsCategory == null)
            {
                return NotFound();
            }

            Category updatedCategory = exitsCategory with
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            _categoriesRepository.UpdateCategory(updatedCategory);

            return NoContent();
        }

        // DELETE /categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(Guid id)
        {
            var category = _categoriesRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoriesRepository.DeleteCategory(id);

            return NoContent();

        }
    }
}