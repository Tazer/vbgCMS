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

        public static ISession OpenSession()
        {
            var session = ServiceLocator.Current.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            return session;
        }

        #region IRegister Members

        public void Execute()
        {
            _application.BeginRequest += delegate
                                             {
                                                 //CurrentSessionContext.Bind(
                                                 //  ServiceLocator.Current.GetInstance<ISessionFactory>().OpenSession());
                                             };
            _application.EndRequest += delegate  
                                           {
                                               var session = ServiceLocator.Current.GetInstance<ISession>();
                                                   //CurrentSessionContext.Unbind(
                                                   //    ServiceLocator.Current.GetInstance<ISessionFactory>());

                                               if (session != null)
                                                   session.Dispose();
                                           };
    }

        #endregion
    }

    public class CustomDatabaseConfiguration
    {
        public static IPersistenceConfigurer Standard()
        {
            var connection = ConfigurationManager.ConnectionStrings["vbg_cms"];

            switch (connection.ProviderName)
            {
                case "MSSQL2008":
                    return
                        MsSqlConfiguration.MsSql2008.ConnectionString(
                            x => x.Is(connection.ConnectionString));
                case "MSSQL2005":
                    return MsSqlConfiguration.MsSql2005.ConnectionString(
    x => x.Is(connection.ConnectionString));
                case "MYSQL":
                    return MySQLConfiguration.Standard.ConnectionString(
                            x => x.Is(connection.ConnectionString));
                case "ORACLE10":
                    return OracleDataClientConfiguration.Oracle10.ConnectionString(
                            x => x.Is(connection.ConnectionString));
                case "SQLITE":
                    return SQLiteConfiguration.Standard.ConnectionString(
    x => x.Is(connection.ConnectionString));

            }
            throw new ArgumentException("Provider not supported , please check providerName");
        }
    }


}
