using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vbgCMS.Infrastructure.CMS;

namespace vbgCMS.UI.Web.Code.Mvc.Controllers
{
    public class CMSController : BaseController
    {
        public Site CurrentSite
        {
            set { ViewData[KeyManager.ViewData.CurrentSite] = value; }
        }
    }
}