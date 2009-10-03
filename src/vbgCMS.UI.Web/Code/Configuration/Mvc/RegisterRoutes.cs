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

        public class AdminAreaRoute : AreaRegistration
        {
            public override string AreaName
            {
                get { return "admin"; }
            }

            public override void RegisterArea(AreaRegistrationContext context)
            {
                context.MapRoute(
                    "admin",
                    "admin/{controller}/{action}/{id}",
                    new { controller = "Home", action = "Index", id = "" },
                    new string[] { "vbgCMS.UI.Web.Areas.Admin.Controllers" }
                    );
            }
        }
        public class InstallAreaRoute : AreaRegistration
        {
            public override string AreaName
            {
                get { return "install"; }
            }

            public override void RegisterArea(AreaRegistrationContext context)
            {
                context.MapRoute("install",
                    "App/{controller}/{action}/{id}",
                    new { controller = "Install", action = "Step1", id = "" },
                    new string[] { "vbgCMS.UI.Web.Areas.Install.Controllers" });
            }
        }

        public class DefaultAreaRoute : AreaRegistration
        {
            public override string AreaName
            {
                get { return "default"; }
            }

            public override void RegisterArea(AreaRegistrationContext context)
            {
                context.MapRoute("default",
                    "{controller}/{action}/{id}",
                    new { controller = "Home", action = "Index", id = "" },
                    new string[] { "vbgCMS.UI.Web.Areas.Default.Controllers" });
            }
        }



        #region IRegister Members

        public void Execute()
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Install.aspx");
            AreaRegistration.RegisterAllAreas();
        }

        #endregion
    }
}
