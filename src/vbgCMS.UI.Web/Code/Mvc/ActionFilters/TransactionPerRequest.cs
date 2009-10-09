using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using NHibernate;

namespace vbgCMS.UI.Web.Code.Mvc.ActionFilters
{
    public class TransactionPerRequest : ActionFilterAttribute
    {
        private ITransaction _transaction;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _transaction = ServiceLocator.Current.GetInstance<ISession>().BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                _transaction.Commit();
            }
            catch (HibernateException)
            {
                _transaction.Rollback();
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}
