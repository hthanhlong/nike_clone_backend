using FluentValidation;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Validators
{
    public class SignUpDtoValidator : AbstractValidator<SignUpDto>
    {
        public SignUpDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull().MinimumLength(6);
            RuleFor(x => x.FirstName).NotNull().MinimumLength(3);
            RuleFor(x => x.LastName).NotNull().MinimumLength(3);
            RuleFor(x => x.RoleId).NotNull();
            RuleFor(x => x.PermissionId).NotNull();
        }
    }
}