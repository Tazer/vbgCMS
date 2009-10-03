using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;

namespace vbgCMS.UI.Web.Code.Mvc
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IController result = null;

            if (controllerType != null)
            {
                try
                {
                    result = ServiceLocator.Current.GetInstance(controllerType) as Controller;
                }
                catch(Exception) { }
            }

            return result ?? base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
