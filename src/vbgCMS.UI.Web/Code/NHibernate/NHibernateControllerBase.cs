using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using NHibernate;

namespace vbgCMS.UI.Web.Code.NHibernate
{
    public abstract class NHibernateControllerBase : Controller
    {
        private ITransaction _transaction;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _transaction = ServiceLocator.Current.GetInstance<ISession>().BeginTransaction();
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //_transaction = ServiceLocator.Current.GetInstance<ISession>().Transaction;

            try
            {
                _transaction.Commit();
            }
            catch (HibernateException)
            {
                _transaction.Rollback();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
