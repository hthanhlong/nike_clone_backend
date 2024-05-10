using FluentValidation;

namespace  Nike_clone_Backend.Models.DTOs
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public required string Slug { get; set; }
    }
}

