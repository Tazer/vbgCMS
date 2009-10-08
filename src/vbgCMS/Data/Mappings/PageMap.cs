using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.CMS;
using FluentNHibernate.Mapping;

namespace vbgCMS.Data.Mappings
{
    public class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0").UnsavedValue(default(long));
            Map(x => x.Title);
            Map(x => x.Slug);

            References<Site>(x => x.Site);

            HasMany<Zone>(x => x.Zones).AsSet();
            HasMany<Widget>(x => x.Widgets).AsSet();
            Version(x => x.Version);
        }
    }
}
