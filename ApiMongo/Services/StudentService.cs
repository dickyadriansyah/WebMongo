using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using DataModel.UnitofWork;
using DataEntities.Request;
using MongoDB.Bson;

namespace Services
{
    public class StudentService : IStudentService
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly Student student;

        public StudentService()
        {
            _unitOfWork = new UnitOfWork();
            student = new Student();
        }

        public List<Student> GetAll()
        {
            return _unitOfWork.Students.GetAll();
        }

        public Student GetById(string id)
        {
            return _unitOfWork.Students.Get(id);
        }

        public Student GetByStudentId(int id)
        {
            //var studentId = student.StudentID;
            //studentId = id;
            return _unitOfWork.Students.GetId(id);
        }

        public bool Insert(Student student)
        {
            bool success = false;
            if(student != null)
            {
                _unitOfWork.Students.Add(student);
                return success = true;
            }
            return success;
        }

        public bool Update(string id, Student student)
        {
            bool success = false;
            if(student != null)
            {
                student.id = new ObjectId(id);
                _unitOfWork.Students.Update(s => s.id, student.id, student);
                return success = true;
            }

            return success;
        }

        public bool Delete(string id)
        {
            bool success = false;
            if (id != null)
            {
                //id = new ObjectId(id);
                _unitOfWork.Students.Delete(s => s.id, ObjectId.Parse(id));
                return success = true;
            }


            return success;
        }

        public List<Student> GetAllActive()
        {
            student.status = "A";
            return _unitOfWork.Students.GetCustomeAll("status", student.status);
        }
    }
}
