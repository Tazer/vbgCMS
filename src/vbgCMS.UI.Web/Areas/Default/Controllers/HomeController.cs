using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vbgCMS.UI.Web.Code.Mvc.Controllers;

namespace vbgCMS.UI.Web.Areas.Default.Controllers
{
    public class HomeController : CMSController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}