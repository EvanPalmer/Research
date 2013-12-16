using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheMvcApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "User Controller Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "UserInfo", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }
    }
}