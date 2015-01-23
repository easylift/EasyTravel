using System.Web.Mvc;

namespace EasyLift.Areas.MongoAreasAPI
{
    public class MongoAreasAPIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MongoAreasAPI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "API_default",
                "MongoAreasAPI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}