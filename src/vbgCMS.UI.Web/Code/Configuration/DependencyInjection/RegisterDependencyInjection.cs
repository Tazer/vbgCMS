using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;
using System.Web.Routing;
using vbgCMS.UI.Web.Code.Configuration.Mvc;
using System.Web.Mvc;
using NHibernate;
using vbgCMS.UI.Web.Code.Configuration.NHibernate;
using NHibernate.Context;
using FluentValidation;
using vbgCMS.Infrastructure.CMS.Interfaces;
using vbgCMS.Data;
using vbgCMS.Infrastructure.CMS;
using vbgCMS.Infrastructure.CMS.Validators;
using vbgCMS.UI.Web.Code.Configuration.Validation;

namespace vbgCMS.UI.Web.Code.Configuration.DependencyInjection
{
    public class RegisterDependencyInjection : IRegister
    {
        private class MvcRegistry : Registry
        {
            public MvcRegistry()
            {
                ForRequestedType<RouteCollection>().TheDefault.IsThis(RouteTable.Routes);
                ForRequestedType<ControllerBuilder>().TheDefault.IsThis(ControllerBuilder.Current);
                ForRequestedType<ViewEngineCollection>().TheDefault.IsThis(ViewEngines.Engines);
                ForRequestedType<ModelBinderDictionary>().TheDefault.IsThis(ModelBinders.Binders);
				ForRequestedType<IValidatorFactory>().TheDefault.Is.ConstructedBy(() => new StructureMapValidationFactory());

                ForRequestedType<IRegister>()
                    .AddConcreteType<RegisterRoutes>()
                    .AddConcreteType<RegisterControllerFactory>()
					.AddConcreteType<RegisterModelBinder>();
            }
        }

        private class NHibernateRegistry : Registry
        {
            public NHibernateRegistry()
            {
                ForRequestedType<ISessionFactory>().CacheBy(InstanceScope.HttpContext).TheDefault.Is.ConstructedBy(ctx =>
                    RegisterNHibernate.Configure().BuildSessionFactory());
                ForRequestedType<ISession>().CacheBy(InstanceScope.HttpContext).TheDefault.Is.ConstructedBy(ctx =>  ctx.GetInstance<ISessionFactory>().GetCurrentSession() /*  CustomSessionContext.CurrentSession */ );
            }
        }

        private class ValidationRegistry : Registry
        {
            public ValidationRegistry()
            {
				ForRequestedType<IValidator<Page>>().TheDefaultIsConcreteType<PageValidator>();
            }
        }

        private class vbgCMSRegistry : Registry
        {
            public vbgCMSRegistry()
            {
                ForRequestedType<IPageRepository>().TheDefaultIsConcreteType<PageRepository>();
            }
        }

        public class StructureMapServiceLocator : ServiceLocatorImplBase
        {

            protected override object DoGetInstance(Type serviceType, string key)
            {
                return string.IsNullOrEmpty(key)
                           ? ObjectFactory.GetInstance(serviceType)
                           : ObjectFactory.GetNamedInstance(serviceType, key);
            }

            protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
            {
                return ObjectFactory.GetAllInstances(serviceType).Cast<object>().AsEnumerable();
            }
        }

        #region IRegister Members

        public void Execute()
        {


            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<MvcRegistry>();
                x.AddRegistry<NHibernateRegistry>();
                x.AddRegistry<ValidationRegistry>();
                x.AddRegistry<vbgCMSRegistry>();
            });

            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator());
        }

        #endregion
    }
}
