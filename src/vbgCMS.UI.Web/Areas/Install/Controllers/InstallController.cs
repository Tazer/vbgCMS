using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using vbgCMS.UI.Web.Code.Configuration.NHibernate;

namespace vbgCMS.UI.Web.Areas.Install.Controllers
{
    public class InstallController : Controller
    {
        //
        // GET: /Install/

        public ActionResult Step1()
        {
            var SchemaExport = new NHibernate.Tool.hbm2ddl.SchemaExport(RegisterNHibernate.Configure());
            //SchemaExport.Drop(false, true);
            SchemaExport.Create(false, true);

            var site = new Site { Name = "vbgCMS" };
            var session = ServiceLocator.Current.GetInstance<ISession>();

            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(site);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            return RedirectToAction("Completed");
        }

        public  ActionResult Completed()
        {
            ViewData["Feedback"] = "Database created. Remove The Areas/Install folder";
            return View();
        }

    }
}
