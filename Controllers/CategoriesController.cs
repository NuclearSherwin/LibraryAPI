using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = (await _categoriesRepository.getAllAsync())
                              .Select(c => c.AsDto());
            return categories;
        }

        // GET /categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> getCategoryAsync(Guid id)
        {
            var category = await _categoriesRepository.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category.AsDto();
        }


        // POST /categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                CreateDate = DateTimeOffset.UtcNow
            };

            await _categoriesRepository.CreateCategoryAsync(category);

            return CreatedAtAction(nameof(getCategoryAsync), new { id = category.Id }, category.AsDto());
        }

        // UPDATE /categories/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(Guid id, CategoryDto categoryDto)
        {
            var exitsCategory = await _categoriesRepository.GetCategoryAsync(id);
            if (exitsCategory == null)
            {
                return NotFound();
            }

            Category updatedCategory = exitsCategory with
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            await _categoriesRepository.UpdateCategoryAsync(updatedCategory);

            return NoContent();
        }

        // DELETE /categories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(Guid id)
        {
            var category = await _categoriesRepository.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            await _categoriesRepository.DeleteCategoryAsync(id);

            return NoContent();

        }
    }
}