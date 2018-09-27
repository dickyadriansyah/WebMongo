using DataEntities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class ApiMongo
    {
        private RestClient _client;
        string url = ConfigurationManager.AppSettings["ApiMongo"];

        public ApiMongo()
        {
            _client = new RestClient()
            {
                BaseUrl = new System.Uri(url)
            };
        }

        public List<Student> GetAllStudent()
        {
            var request = new RestRequest()
            {
                Resource = "/api/Student",
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            //request.AddBody(model);
            var response = _client.Execute<List<Student>>(request);
            return response.Data;
        }

        public Student GetById(string id)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Student/" + id,
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = _client.Execute<Student>(request);
            return response.Data;
        }

        public bool CreateStudent(Student student)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Student",
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddBody(student);
            var response = _client.Execute<bool>(request);

            if(student != null)
            {
                response.Data = true;
            }
            return response.Data;
        }

        public bool UpdateStudent(string id, Student student)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Student/" + id,
                Method = Method.PUT,
                RequestFormat = DataFormat.Json
            };
            request.AddBody(student);
            var response = _client.Execute<bool>(request);

            return response.Data;
        }

        public bool DeleteStudent(string id)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Student/" + id,
                Method = Method.DELETE,
                RequestFormat = DataFormat.Json
            };
            var response = _client.Execute<bool>(request);

            return response.Data;
        }

    }
}
