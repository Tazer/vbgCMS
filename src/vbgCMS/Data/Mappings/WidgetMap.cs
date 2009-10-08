using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.CMS;
using FluentNHibernate.Mapping;
using vbgCMS.Infrastructure.CMS.Widgets.Standard;

namespace vbgCMS.Data.Mappings
{
    public class WidgetMap : ClassMap<Widget>
    {
        public WidgetMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0").UnsavedValue(default(long));
            Map(x => x.View).Column("`View`");

            References<Page>(x => x.Page);
            References<Zone>(x => x.Zone);
            Version(x => x.Version);
        }
    }

    public class TextWidGetMap : SubclassMap<TextWidget>
    {
        public TextWidGetMap()
        {
            Map(x => x.Data);
        }
    }
}
