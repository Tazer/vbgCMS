using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vbgCMS.UI.Web.Code;
using vbgCMS.UI.Web.Code.Mvc.TagBuilders;
using vbgCMS.Infrastructure.CMS;

namespace vbgCMS.UI.Web.Areas.Admin.Helpers
{
    public static class ZoneHelpers
    {
        public static IDictionary<string, string> ZoneTemplates(this ViewContext context)
        {
            return (IDictionary<string, string>)context.ViewData[KeyManager.ViewData.ZoneTemplatesList];
        }

        public static IDictionary<string, string> ZoneTemplates(this ViewPage view)
        {
            return view.ViewContext.ZoneTemplates();
        }

        public static IDictionary<string, string> ZoneTemplates(this ViewUserControl view)
        {
            return view.ViewContext.ZoneTemplates();
        }

        public static ZoneTag BeginZone(this HtmlHelper html, Zone model)
        {
            return new ZoneTag(html.ViewContext.HttpContext.Response).Build(model.Id.ToString(), model.Width);
        }
    }
}
