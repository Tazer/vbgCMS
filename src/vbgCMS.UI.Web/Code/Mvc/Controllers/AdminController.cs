using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vbgCMS.UI.Web.Code.Mvc.Controllers
{
    public class AdminController : BaseController
    {
        public IDictionary<string, string> ZoneTemplates
        {
            set { ViewData[KeyManager.ViewData.ZoneTemplatesList] = value; }
        }
    }
}
