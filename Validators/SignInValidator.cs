using FluentValidation;
using Reformation.Classes;

namespace Reformation.Validators
{
    public class SignInValidator : AbstractValidator<ISignIn>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}