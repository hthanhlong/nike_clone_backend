using FluentValidation;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Validators
{
    public class PermissionModelValidator : AbstractValidator<PermissionModel>
    {
        public PermissionModelValidator()
        {
            RuleFor(x => x.Action).NotEmpty().WithMessage("Action is required");
            RuleFor(x => x.Resource).NotEmpty().WithMessage("Resource is required");
        }

    }
}