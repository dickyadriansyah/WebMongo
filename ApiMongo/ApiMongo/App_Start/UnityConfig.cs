﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.WebApi;
using Utilities.Resolver;

namespace ApiMongo.App_Start
{
    public static class UnityConfig
    {

        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            ComponentLoader.LoadContainer(container, ".\\bin", "DataModel.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "Utilities.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "Services.dll");
            return container;
        }

    }
}