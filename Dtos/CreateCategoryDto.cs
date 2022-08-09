using System.ComponentModel.DataAnnotations;

namespace Library.Dtos
{
    public record CreateCategoryDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string Description { get; init; }
    }
}