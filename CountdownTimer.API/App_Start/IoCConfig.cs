using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CountdownTimer.Data.Repository;
using CountdownTimer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CountdownTimer.API.App_Start
{
    public static class IocConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<InventoryService>().As<IInventoryService>();
            builder.RegisterType<ItemRepository>().As<IItemRepository>().SingleInstance();
            builder.RegisterType<TimerService>().As<ITimerService>();
            builder.RegisterType<TimerRepository>().As<ITimerRepository>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}