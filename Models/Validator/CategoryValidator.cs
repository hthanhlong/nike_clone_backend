using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Reformation.Models.Validator
{
    public class CategoryValidator : AbstractValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).Length(0, 10);
            RuleFor(x => x.Description).Length(0, 10);
            RuleFor(x => x.Image).Length(0, 10);
            RuleFor(x => x.Slug).Length(0, 10);
        }
    }
}