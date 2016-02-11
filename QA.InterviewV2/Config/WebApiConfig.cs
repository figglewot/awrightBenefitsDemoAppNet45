using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace QA.InterviewV2.Config
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                name: "EmployeesApi",
                routeTemplate: "api/employees/{id}",
                defaults: new { controller = "employees", id = RouteParameter.Optional });

            configuration.Routes.MapHttpRoute(
                name: "DependentsApi",
                routeTemplate: "api/employees/{id}/dependents",
                defaults: new { controller = "dependents" });

            var jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}