using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CurrencyExchangeService.FrontEnd
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}