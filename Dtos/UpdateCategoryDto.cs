using System.ComponentModel.DataAnnotations;

namespace Library.Dtos
{
    public record UpdateCategoryDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string Description { get; init; }
    }
}