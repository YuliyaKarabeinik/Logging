using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcMusicStore.Controllers;
using MvcMusicStore.PerformanceCounters;
using NLog;
using PerformanceCounterHelper;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitLogger();
            //InitPerformanceCounters();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Test project"))
            {
                counterHelper.RawValue(Counters.GoToHome, 0);
            }
        }

        private void InitLogger()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.Register(f => LogManager.GetLogger("For Controllers")).As<ILogger>();

            DependencyResolver.SetResolver(
                new AutofacDependencyResolver(builder.Build()));
        }

        private void InitPerformanceCounters()
        {
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Test project"))
            {
                counterHelper.RawValue(Counters.GoToHome, 0);
            }
        }
    }
}
