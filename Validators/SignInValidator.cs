using FluentValidation;
using Nike_clone_Backend.Classes;

namespace Nike_clone_Backend.Validators
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