using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Reformation.Models;

namespace Reformation.Validators
{
    public class RoleModelValidator : AbstractValidator<RoleModel>
    {
        public RoleModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }

    }
}