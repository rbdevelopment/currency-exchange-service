using System.Net.Http;
using Autofac;

namespace CurrencyExchangeService.BusinessLogic
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpClient>().AsSelf();
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}