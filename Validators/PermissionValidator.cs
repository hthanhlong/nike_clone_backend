using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Reformation.Models;

namespace Reformation.Validators
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