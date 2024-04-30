using FluentValidation;
using Reformation.Classes;

namespace Reformation.Validators
{
    public class SignInInputValidator : AbstractValidator<SignInInput>
    {
        public SignInInputValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}