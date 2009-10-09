using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using NHibernate;

namespace vbgCMS.UI.Web.Code.Mvc.Controllers
{
    public abstract class NHibernateController : Controller
    {
        private ITransaction _transaction;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _transaction = ServiceLocator.Current.GetInstance<ISession>().BeginTransaction();
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            base.OnActionExecuted(filterContext);
        }
    }
}