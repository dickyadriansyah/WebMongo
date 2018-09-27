using DataEntities;
using DataModel.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MongoDatabase _database;

        public Repository<Student> _students { get; set; }


        public UnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_students == null)
                    _students = new Repository<Student>(_database, "student");
                return _students;
            }
        }
    }
}
