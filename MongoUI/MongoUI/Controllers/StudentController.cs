using DataEntities;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoUI.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        private StudentLogic student;

        public StudentController()
        {
            student = new StudentLogic();
        }

        public ActionResult Index()
        {
            //var result = student.GetAllStudent();
            return View();
        }

        public JsonResult GetStudent()
        {
            var result = student.GetAllStudent();
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult GetById(string Id)
        {
            var data_student = student.GetById(Id);
            return Json(data_student, JsonRequestBehavior.AllowGet);
            
        }

        public string InsertStudent(Student s)
        {
            if (s != null)
            {

                student.CreateStudent(s);
                return "Student Added Successfully";
             
            }
            else
            {
                return "Student Not Inserted! Try Again";
            }
        }
        
        public string UpdateStudent(string id, Student s)
        {
            if(s != null)
            {
                student.UpdateStudent(id, s);
                return "Student Update Successfully";
            }else
            {
                return "Student Not Updated! Try Again";
            }
        }

        public string DeleteStudent(string id)
        {
            if(id != null)
            {
                student.DeleteStudent(id);
                return "Student Delete Successfully";
            }else
            {
                return "Student Not Delete! Try Again";
            }
        }
        
    }
}