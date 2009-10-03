using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HibernatingRhinos.NHibernate.Profiler.Appender;
using vbgCMS.UI.Web.Code.Configuration;
using vbgCMS.UI.Web.Code.Configuration.NHibernate;

namespace vbgCMS.UI.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            new RegisterNHibernate(this).Execute();
        }

        protected void Application_Start()
        {
            NHibernateProfiler.Initialize();
            new BootStrapper().Run();
        }
    }
}