using FluentValidation;
using nike_clone_backend.Models.DTOs;

namespace nike_clone_backend.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}