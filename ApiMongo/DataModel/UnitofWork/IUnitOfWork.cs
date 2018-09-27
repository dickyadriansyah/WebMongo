using DataEntities;
using DataModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitofWork
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
    }
}
