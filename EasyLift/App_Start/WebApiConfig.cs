﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EasyLift
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("MongoAreasAPI",
                "MongoAreasAPI/api/{controller}/{id}",
                new {id = RouteParameter.Optional});


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
