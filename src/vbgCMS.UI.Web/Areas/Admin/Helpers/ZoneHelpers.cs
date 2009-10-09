using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vbgCMS.UI.Web.Code;

namespace vbgCMS.UI.Web.Areas.Admin.Helpers
{
    public static class ZoneHelpers
    {
        public static IDictionary<string, string> ZoneTemplates(this ViewPage view)
        {
            return (IDictionary<string, string>)view.ViewData[KeyManager.ViewData.ZoneTemplatesList];
        }

        public static IDictionary<string, string> ZoneTemplates(this ViewUserControl view)
        {
            return (view.Page as ViewPage).ZoneTemplates();
        }
    }
}
