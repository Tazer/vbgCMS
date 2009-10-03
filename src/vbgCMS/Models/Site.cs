using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Models;

namespace vbgCMS
{
    public class Site : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
