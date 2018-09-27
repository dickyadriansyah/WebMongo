using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        List<TEntity> GetAll();

        List<TEntity> GetCustomeAll(string action1, string action2);

        TEntity Get(string id);

        TEntity GetId(int id);

        void Update(Expression<Func<TEntity, ObjectId>> queryExpression, ObjectId id, TEntity entity);

        void Delete(Expression<Func<TEntity, ObjectId>> queryExpression, ObjectId id);
    }
}
