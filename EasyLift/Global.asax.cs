using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EasyLift.DependencyResolution;
using EasyLift.Registries;
using StructureMap;

namespace EasyLift
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new Container(c => c.AddRegistry<StandardRegistry>());

            DependencyResolver.SetResolver(new StructureMapDependencyScope(container));
            DependencyResolver.SetResolver(new StructureMapWebApiDependencyScope(container));
        }
    }
}
