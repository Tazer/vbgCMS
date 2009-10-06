using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vbgCMS.UI.Web.Code;
using vbgCMS.Infrastructure.CMS;

namespace vbgCMS.UI.Web.Areas.Default.Helpers
{
    public static class SiteExtensions
    {
        public static Site CurrentSite(this ViewPage view)
        {
            return (Site)view.ViewData[KeyManager.ViewData.CurrentSite];
        }
    }
}
