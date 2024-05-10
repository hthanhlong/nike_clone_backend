using Nike_clone_Backend.Models.DTOs;
using FluentValidation;

namespace Nike_clone_Backend.Validators
{
    public class RoleModelValidator : AbstractValidator<CreateRoleDto>
    {
        public RoleModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }

    }
}