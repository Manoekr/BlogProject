using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title).MinimumLength(2).WithMessage("2 karekterden az olamaz");
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Content).MinimumLength(10).WithMessage("10 karekterden az olamaz");
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.Tag).Must(StartWithTag).WithMessage("Tag # ile başlamalıdır");
        }
        private bool StartWithTag(string arg)
        {
            return arg.StartsWith("#");
        }
    }
}
