using DataEntities;
using DataEntities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IStudentService
    {
        List<Student> GetAll();

        List<Student> GetAllActive();

        Student GetById(string id);

        Student GetByStudentId(int id);

        bool Insert(Student student);

        bool Update(string id, Student student);

        bool Delete(string id);
    }
}
