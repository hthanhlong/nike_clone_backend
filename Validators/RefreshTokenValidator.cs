using FluentValidation;
using Nike_clone_Backend.Classes;

namespace Nike_clone_Backend.Validators
{
    public class RefreshTokenValidator : AbstractValidator<IRefreshToken>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken is required");
        }
    }
}