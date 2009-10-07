using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.Base;

namespace vbgCMS.Infrastructure.CMS
{
    public class Page : BaseEntity
    {
        public Page()
        {
            Zones = new HashSet<Zone>();
            Widgets = new HashSet<Widget>();
        }

        public virtual Site Site { get; set; }

        public virtual string Title { get; set; }
        public virtual string Slug { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }
        public virtual ICollection<Widget> Widgets { get; set; }

        public override int GetHashCode()
        {
            return (Slug ?? string.Empty).GetHashCode(); // +base.GetHashCode();
        }
    }
}
