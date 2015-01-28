using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Infrastructure.Task;
using EasyLift.DependencyResolution;
using EasyLift.Registries;
using StructureMap;

namespace EasyLift
{
    public class MvcApplication : HttpApplication
    {
        public IContainer Container
        {
            get{return (IContainer)HttpContext.Current.Items["_Container"];}
            set{HttpContext.Current.Items["_Container"] = value;}
        }
        protected void Application_Start()
        {
            EnsureAuthIndexes.Exist();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new Container(c => c.AddRegistry<StandardRegistry>());

            DependencyResolver.SetResolver(new StructureMapDependencyScope(container));
            DependencyResolver.SetResolver(new StructureMapWebApiDependencyScope(container));

            using (var item = container.GetNestedContainer())
            {
                foreach (var task in item.GetAllInstances<IRunAtInit>())
                {
                    task.Execute();
                }

                foreach (var task in container.GetAllInstances<IRunAtStartup>())
                {
                    task.Execute();
                }
            }
        }

        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();

            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {
            try
            {
                foreach (var task in
                    Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}
