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
        public virtual long Version { get; set; }

        public override int GetHashCode()
        {
            return (Slug ?? string.Empty).GetHashCode(); // +base.GetHashCode();
        }

        public virtual void AddZonesFromTemplateString(string template)
        {
            string[] zones = template.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < zones.Length; i++)
            {
                int width;
                if (int.TryParse(zones[i], out width))
                {
                    this.Zones.Add(new Zone() { Position = i, Width = width, Page = this });
                }
            }
        }
    }
}
