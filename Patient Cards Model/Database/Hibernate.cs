using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Patient_Cards_Model.Entities;
using Patient_Cards_Model.Helpers;
using NHibernate.Tool.hbm2ddl;

namespace Patient_Cards_Model.Database
{
    public static class Hibernate
    {
        private static ISessionFactory sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = Fluently
                        .Configure()
                        .Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("Db/PatientCards.db"))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Card>())
                        .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                        .BuildSessionFactory();
                }
                return sessionFactory;
            }
        }

        public static void CheckConnection()
        {
            using (var session = SessionFactory.OpenSession()) { }
        }
    }
}
