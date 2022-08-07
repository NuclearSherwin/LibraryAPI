using System.ComponentModel.DataAnnotations;

namespace Library.Dtos
{
    public record UpdateCategoryDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(0, 1000)]
        public string Description { get; init; }
    }
}