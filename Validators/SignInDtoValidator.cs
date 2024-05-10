using FluentValidation;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Validators
{
    public class SignInDtoValidator : AbstractValidator<SignInDto>
    {
        public SignInDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}