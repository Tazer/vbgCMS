using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.Base;

namespace vbgCMS.Infrastructure.CMS
{
    public abstract class Widget : BaseEntity
    {
        public virtual Page Page { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual long Version { get; set; }
        public virtual string View { get; set; }
    }

    public abstract class Widget<T> : Widget
    {
        public virtual T Data { get; set; }
    }
}
