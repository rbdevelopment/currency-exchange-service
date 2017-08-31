using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace CurrencyExchangeService.FrontEnd
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // WebAPI 2
            config.DependencyResolver = new AutofacWebApiDependencyResolver(DependencyInjectionGenerator.Container);
            // MVC 5
            DependencyResolver.SetResolver(new AutofacDependencyResolver(DependencyInjectionGenerator.Container));
        }
    }
}