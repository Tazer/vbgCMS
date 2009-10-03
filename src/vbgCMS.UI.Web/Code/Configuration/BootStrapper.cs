using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vbgCMS.UI.Web.Code.Configuration.DependencyInjection;
using Microsoft.Practices.ServiceLocation;

namespace vbgCMS.UI.Web.Code.Configuration
{
    public static class BootStrapper
    {
        static BootStrapper()
        {
            Configure();
        }

        private static void Configure()
        {
            new RegisterDependencyInjection().Execute();
        }

        public static void Run()
        {
            foreach (var register in ServiceLocator.Current.GetAllInstances<IRegister>())
                register.Execute();
        }
    }
}
