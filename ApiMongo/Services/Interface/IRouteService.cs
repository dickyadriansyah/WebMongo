using DataEntities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IRouteService
    {
        Response ServiceDispatcher(GenericRequest request);
    }
}
