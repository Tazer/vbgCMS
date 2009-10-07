using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.Base;
using Iesi.Collections.Generic;

namespace vbgCMS.Infrastructure.CMS
{
    public class Page : BaseEntity
    {
        public virtual Site Site { get; set; }

        public virtual string Title { get; set; }
        public virtual string Slug { get; set; }

        public virtual ISet<Zone> Zones { get; set; }
        public virtual ISet<Widget> Widgets { get; set; }

        public override int GetHashCode()
        {
            return Slug.GetHashCode(); // +base.GetHashCode();
        }
    }
}
