using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using vbgCMS.Infrastructure.CMS;

namespace vbgCMS.Data.Mappings
{
    public class SiteMap : ClassMap<Site>
    {
        public SiteMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0").UnsavedValue(default(long));
            Map(x => x.Name);
        }
    }
}
