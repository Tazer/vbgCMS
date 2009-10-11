using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Cfg = NHibernate.Cfg;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.Context;
using Caches = NHibernate.Caches;

namespace vbgCMS.UI.Web.Code.Configuration.NHibernate
{
    public class RegisterNHibernate : IRegister
    {
        private readonly HttpApplication _application;

        public RegisterNHibernate(HttpApplication application)
        {
            _application = application;
        }

        public static Cfg.Configuration Configure()
        {
            //"managed_web", "call", "thread_static", and "web"
            return
                Fluently.Configure().Database(
                   CustomDatabaseConfiguration.Standard()).
                    Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.Load("vbgCMS"))).ExposeConfiguration(
                    x => x.SetProperty("current_session_context_class", "web")).BuildConfiguration();
        }

        #region IRegister Members

        public void Execute()
        {
            _application.BeginRequest += delegate
                                             {
                                                 //CustomSessionContext.CurrentSession =
                                                 //    ServiceLocator.Current.GetInstance<ISessionFactory>().OpenSession();
                                                 CurrentSessionContext.Bind(
                                                   ServiceLocator.Current.GetInstance<ISessionFactory>().OpenSession());
                                             };
            _application.EndRequest += delegate  
                                           {
                                               var session = 
                                                   //CustomSessionContext.CurrentSession;
                                                   CurrentSessionContext.Unbind(
                                                       ServiceLocator.Current.GetInstance<ISessionFactory>());

                                               if (session != null)
                                                   session.Dispose();
                                           };
    }

        #endregion
    }

    //public static class CustomSessionContext
    //{
    //    public static ISession  CurrentSession
    //    {
    //        get { return (ISession)HttpContext.Current.Items["current.session"]; }
    //        set { HttpContext.Current.Items["current.session"] = value; }
    //    }
    //}

    public class CustomDatabaseConfiguration
    {


        public static IPersistenceConfigurer Standard()
        {
            var connection = ConfigurationManager.ConnectionStrings["vbg_cms"];

            //Findout how to set it by string, get it from appsettings
            switch (connection.ProviderName)
            {
                case "MSSQL2008":
                    return
                        MsSqlConfiguration.MsSql2008.ConnectionString(
                            x => x.Is(connection.ConnectionString)).Cache(x => x.ProviderClass<Caches.SysCache.SysCacheProvider>());
                case "MSSQL2005":
                    return MsSqlConfiguration.MsSql2005.ConnectionString(
                            x => x.Is(connection.ConnectionString)).Cache(x => x.ProviderClass<Caches.SysCache.SysCacheProvider>());
                case "MYSQL":
                    return MySQLConfiguration.Standard.ConnectionString(
                            x => x.Is(connection.ConnectionString)).Cache(x => x.ProviderClass<Caches.SysCache.SysCacheProvider>());
                case "ORACLE10":
                    return OracleDataClientConfiguration.Oracle10.ConnectionString(
                            x => x.Is(connection.ConnectionString)).Cache(x => x.ProviderClass<Caches.SysCache.SysCacheProvider>());
                case "SQLITE":
                    return SQLiteConfiguration.Standard.ConnectionString(
                            x => x.Is(connection.ConnectionString)).Cache(x => x.ProviderClass<Caches.SysCache.SysCacheProvider>());

            }
            throw new ArgumentException("Provider not supported , please check providerName");
        }
    }


}
