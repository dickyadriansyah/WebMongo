using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Resolver;

namespace Services
{
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IRouteService, RouteService>();
            registerComponent.RegisterType<IStudentService, StudentService>();
        }
    }
}
