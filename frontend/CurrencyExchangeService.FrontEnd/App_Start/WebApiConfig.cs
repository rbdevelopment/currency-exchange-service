using System.Web.Http;

namespace CurrencyExchangeService.FrontEnd
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            DependencyInjectionConfig.Register(config);
            config.MapHttpAttributeRoutes();
        }
    }
}