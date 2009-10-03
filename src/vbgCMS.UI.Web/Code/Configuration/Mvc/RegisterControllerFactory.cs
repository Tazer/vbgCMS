using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vbgCMS.UI.Web.Code.Mvc;

namespace vbgCMS.UI.Web.Code.Configuration.Mvc
{
    public class RegisterControllerFactory : IRegister
    {
        private readonly ControllerBuilder controllerBuilder;

        public RegisterControllerFactory(ControllerBuilder controllerBuilder)
        {
            this.controllerBuilder = controllerBuilder;
        }

        #region IRegister Members

        public void Execute()
        {
            controllerBuilder.SetControllerFactory(new ControllerFactory());
        }

        #endregion
    }
}
