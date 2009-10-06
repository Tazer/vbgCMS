using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.Base;

namespace vbgCMS.Infrastructure.CMS
{
    public class Zone : BaseEntity
    {
        public virtual Page Page { get; set; }

        //public string Name { get; set; }
        public virtual int Position { get; set; }
        public virtual int Width { get; set; }
    }
}
