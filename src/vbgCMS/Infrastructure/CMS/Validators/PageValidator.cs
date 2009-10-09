using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using vbgCMS.Infrastructure.Base.Validators;

namespace vbgCMS.Infrastructure.CMS.Validators
{
    public class PageValidator : BaseEntityValidator<Page>
    {
        public PageValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Slug).NotEmpty();
        }
    }
}
