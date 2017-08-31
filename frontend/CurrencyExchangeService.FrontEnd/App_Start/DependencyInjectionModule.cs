using Autofac;
using CurrencyExchangeService.BusinessLogic;

namespace CurrencyExchangeService.FrontEnd
{
    public class DependencyInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusinessLogicModule>();
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}