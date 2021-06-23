using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using Paineis.Api.Filters;

namespace Paineis.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.DocumentFilter<SwaggerAuthTokenOperationFilter>();
                c.SingleApiVersion("V1", "Paineis API");
                c.PrettyPrint();
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
                c.OperationFilter<SwaggerAuthorizationHeaderFilter>();
            }).EnableSwaggerUi(c =>
            {
                c.DocumentTitle("Paineis API");
            });

            SwaggerConfig.MapRoutes(config);
        }

        private static string GetXmlCommentsPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"\bin\Paineis.Api.XML";
        }

        private static void MapRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger")
            );
        }
    }
}
