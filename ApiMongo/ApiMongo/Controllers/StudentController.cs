using DataEntities;
using Services;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiMongo.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        public async Task<HttpResponseMessage> GetAll()
        {
            var students = _studentService.GetAllActive();
            if (students.Any())
            {
                //var d = JsonConvert.SerializeObject(students);
                return Request.CreateResponse(HttpStatusCode.OK, students);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Students Not Found");
        }

        public async Task<HttpResponseMessage> GetById(string id)
        {
            var student = _studentService.GetById(id);
            if (student != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Students Not Found");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Student student)
        {
            if (student != null)
            {
                var data = _studentService.Insert(student);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, student);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, ModelState);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]Student student, string id = "")
        {
            if (id != null)
            {
                var data = _studentService.Update(id, student);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, ModelState);
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            if (id != null)
            {
                var data = _studentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, ModelState);
        }
    }
}
