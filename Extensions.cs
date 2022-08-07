using Library.Dtos;
using Library.Entities;

namespace Library
{
    public static class Extensions
    {
        public static CategoryDto AsDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreateDate = category.CreateDate
            };
        }
    }
}