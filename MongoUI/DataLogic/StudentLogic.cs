using DataEntities;
using Newtonsoft.Json;
using ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class StudentLogic
    {
        private ApiMongo service;
        //private Student student;

        public StudentLogic()
        {
            service = new ApiMongo();
            //student = new Student();
        }


        public List<Student> GetAllStudent()
        {
            var result = new List<Student>();
            var output = service.GetAllStudent();
            result = output;
            return result;
        }

        public Student GetById(string id)
        {
            var data_student = new Student();
            var output = service.GetById(id);
            data_student = output;
            return data_student;
        }

        public bool CreateStudent(Student student)
        {
            var success = false;
            if(student != null)
            {
                success = true;
                var output = service.CreateStudent(student);
                success = output;
            }
            return success;
        }

        public bool UpdateStudent(string id, Student student)
        {
            var success = false;
            if(student != null)
            {
                success = true;
                var output = service.UpdateStudent(id, student);
                success = output;
            }
            return success;
        }

        public bool DeleteStudent(string id)
        {
            var success = false;
            if(id != null)
            {
                success = true;
                var output = service.DeleteStudent(id);
                success = output;
            }
            return success;
        }
    }
}
