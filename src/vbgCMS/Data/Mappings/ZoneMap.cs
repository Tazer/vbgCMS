using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.CMS;
using FluentNHibernate.Mapping;

namespace vbgCMS.Data.Mappings
{
    public class ZoneMap : ClassMap<Zone>
    {
        public ZoneMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0").UnsavedValue(default(long));
            Map(x => x.Position);
            Map(x => x.Width);

            References<Page>(x => x.Page);
        }
    }
}
