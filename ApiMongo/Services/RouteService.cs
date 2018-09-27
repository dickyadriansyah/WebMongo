using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities.Request;
using DataModel.UnitofWork;
using Newtonsoft.Json;

namespace Services
{
    internal class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentService _studentsService;

        public RouteService(IUnitOfWork unitOfWork, IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _studentsService = studentService;
        }

        public Response ServiceDispatcher(GenericRequest request)
        {
            var response = new Response();
            var action = request.action;

            if(action.Trim().Equals("GetAll", StringComparison.InvariantCultureIgnoreCase))
            {
                var result = _studentsService.GetAll();
                var d = JsonConvert.SerializeObject(result);
                response.data = d;
            }

            response.message = "success";
            return response;
        }
    }
}
