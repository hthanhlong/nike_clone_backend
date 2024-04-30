using FluentValidation;
using Reformation.Classes;
using Reformation.Models;

namespace Reformation.Validators
{
    public class SignUpInputValidator : AbstractValidator<SignUpInput>
    {
        public SignUpInputValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull().MinimumLength(6);
            RuleFor(x => x.FirstName).NotNull().MinimumLength(3);
            RuleFor(x => x.LastName).NotNull().MinimumLength(3);
        }
    }
}