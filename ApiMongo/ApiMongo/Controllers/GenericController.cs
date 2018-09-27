using DataEntities.Request;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMongo.Controllers
{
    public class GenericController : ApiController
    {
        private readonly IRouteService _routeService;

        public GenericController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [Route("v1/Generic")]
        [HttpPost]
        public Response Generic(GenericRequest request)
        {
            return _routeService.ServiceDispatcher(request);
        }
    }
}
