using FluentValidation;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Validators
{
    public class PermissionModelValidator : AbstractValidator<CreatePermissionDto>
    {
        public PermissionModelValidator()
        {
            RuleFor(x => x.Action).NotEmpty().WithMessage("Action is required");
            RuleFor(x => x.Resource).NotEmpty().WithMessage("Resource is required");
        }

    }
}