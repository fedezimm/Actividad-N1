using System;
using System.Data;
using System.Linq;
using System.Reflection;

using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
//using NHibernateDemoApp.Domain;
//using NHibernateDemoApp.Mappings;

using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate;

namespace nhibernateg7
{
    class ProgramNHibernate
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = @"Server=.\sqlexpress;initial catalog=NHibernateTest;Integrated Security=true;";
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });

            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<PersonMapping>();
            modelMapper.AddMapping<CarMapping>();

            var mapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mapping, "Test");

            var schema = new SchemaExport(configuration);


            // schema.Execute(false, true, false); 
            //ejecutar solo la primera vez

            //paso 1
            insertarDatos(configuration); 
            //paso 2
            //verDatos(configuration); 
            // paso 3
            // actualizarDatos(configuration)
            // paso 4 
           // deleteDatos(configuration);

        }

        public static void insertarDatos(Configuration cf)
        {
            var buildSessionFactory = cf.BuildSessionFactory();
            using (var session = buildSessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var person = new Person
                {
                    FirstName = "raul",
                    LastName = "than",
                    Car = new Car { Make = "volvawen", Model = "megan", Year = "2013" }
                };
                session.Save(person);
                tx.Commit();
                
            }


        }
        public static void verDatos(Configuration cf)
        {
            var buildSessionFactory = cf.BuildSessionFactory();
            using (var session = buildSessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var person = session.Query<Person>()
                           .Where(p => p.FirstName == "Linda")
                           .Select(p => p.LastName)
                           .First();

                Console.WriteLine(person);
                Console.ReadLine();
                tx.Commit();
            }

        }

        public static void actualizarDatos(Configuration cf)
        {
            var buildSessionFactory = cf.BuildSessionFactory();
            using (var session = buildSessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                //IQuery query = session.CreateQuery("FROM Car WHERE ID = 1");
                //Car c = query.List<Car>()[0];
                //c.Year= "1988";
                //session.Update(c);
                //Console.WriteLine(c.Year);
                var person = session.QueryOver<Person>().Where(p => p.FirstName == "Linda").List();
                person.FirstOrDefault().Car.Year = "1968";
                session.Update(person.FirstOrDefault());
                Console.WriteLine(person.ToString());
                Console.ReadLine();
                tx.Commit();
                
            }
        }

        public static void deleteDatos(Configuration cf)
        {

            {
                var buildSessionFactory = cf.BuildSessionFactory();
                using (var session = buildSessionFactory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                   
                    var person = session.QueryOver<Person>().Where(p => p.FirstName == "raul").List();
                    session.Delete(person.FirstOrDefault());
                    tx.Commit();
                   
                }

            }
        }

    }

  

}

