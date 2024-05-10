using FluentValidation;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Validators
{
    public class RefreshTokenDtoValidator : AbstractValidator<RefreshTokenDto>
    {
        public RefreshTokenDtoValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken is required");
        }
    }
}