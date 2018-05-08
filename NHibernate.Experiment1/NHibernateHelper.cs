using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.Experiment1
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitilizeSessionFactory();
                return _sessionFactory;
            }
        }
        public static void InitilizeSessionFactory()
        {
           var connectionString= @"Data Source=(local);Initial Catalog=NhiberateDemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
             _sessionFactory = Fluently.Configure().Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(m=>m.FluentMappings.
                AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg=>new SchemaExport(cfg)
                .Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}