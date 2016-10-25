using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MinutradeApp
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
      var corsAttr = new EnableCorsAttribute("http://localhost:85", "*", "*");
      config.EnableCors(corsAttr);
      corsAttr = new EnableCorsAttribute("http://127.0.0.1:58295", "*", "*");
      config.EnableCors(corsAttr);
      config.Formatters.Remove(config.Formatters.XmlFormatter);
    }
  }
}
