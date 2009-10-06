using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Models;
using vbgCMS.Infrastructure.Base;

namespace vbgCMS.Infrastructure.CMS
{
    public class Site : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
