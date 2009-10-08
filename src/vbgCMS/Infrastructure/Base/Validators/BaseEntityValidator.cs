using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace vbgCMS.Infrastructure.Base.Validators
{
    public class BaseEntityValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        public BaseEntityValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
