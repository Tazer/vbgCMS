using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.CMS.Widgets.Standard;
using FluentNHibernate.Mapping;

namespace vbgCMS.Data.Mappings
{
    public class TextWidgetMap : SubclassMap<TextWidget>
    {
        public TextWidgetMap()
        {
            Map(x => x.Data);
        }
    }
}
