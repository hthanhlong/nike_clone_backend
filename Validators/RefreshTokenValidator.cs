using FluentValidation;
using Reformation.Classes;

namespace Reformation.Validators
{
    public class RefreshTokenValidator : AbstractValidator<IRefreshToken>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken is required");
        }
    }
}