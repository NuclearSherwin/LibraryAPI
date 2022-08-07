using System;

namespace Library.Entities
{
    public record Category
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTimeOffset CreateDate { get; set; }
    }
}