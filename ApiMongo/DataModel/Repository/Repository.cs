using DataEntities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataModel.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<T> _collection;

        public Repository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<T>(tblName);
        }

        public List<T> GetAll()
        {
            MongoCursor<T> cursor = _collection.FindAll();
            
            return cursor.ToList();
        }

        public T Get(string id)
        {
            return _collection.FindOneById(ObjectId.Parse(id));
        }

        public T GetId(int id)
        {
            var query_id = Query.EQ("StudentID", id.ToString());
            return _collection.FindOne(query_id);
        }

        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        public void Update(Expression<Func<T, ObjectId>> queryExpression, ObjectId id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(entity));
        }

        public void Delete(Expression<Func<T, ObjectId>> queryExpression, ObjectId id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }

        public List<T> GetCustomeAll(string action1, string action2)
        {
            var query = Query.EQ(action1, action2);
            MongoCursor<T> cursor = _collection.Find(query);
            return cursor.ToList();
        }
    }
}
