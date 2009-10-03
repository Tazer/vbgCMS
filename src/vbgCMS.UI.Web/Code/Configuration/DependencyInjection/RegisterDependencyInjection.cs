using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using System.Web.Routing;
using vbgCMS.UI.Web.Code.Configuration.Mvc;

namespace vbgCMS.UI.Web.Code.Configuration.DependencyInjection
{
    public class RegisterDependencyInjection : IRegister
    {
        private class MvcRegistry : Registry
        {
            public MvcRegistry()
            {
                var x = this;

                x.ForRequestedType<RouteCollection>().TheDefault.IsThis(RouteTable.Routes);

                x.ForRequestedType<IRegister>()
                    .AddConcreteType<RegisterRoutes>();
            }
        }

        #region IRegister Members

        public void Execute()
        {
            ObjectFactory.Initialize(x => {
                x.AddRegistry<MvcRegistry>();
            });
        }

        #endregion
    }
}
