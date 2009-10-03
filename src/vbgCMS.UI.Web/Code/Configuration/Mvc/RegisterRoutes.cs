using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vbgCMS.UI.Web.Code.Configuration.Mvc
{
    public class RegisterRoutes : IRegister
    {
        private readonly RouteCollection routes;

        public RegisterRoutes(RouteCollection routes)
        {
            this.routes = routes;
        }

        #region IRegister Members

        public void Execute()
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        #endregion
    }
}
