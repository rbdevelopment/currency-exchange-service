using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace CurrencyExchangeService.FrontEnd
{
    public static class DependencyInjectionGenerator
    {
        /// <summary>
        ///     The container instance.
        /// </summary>
        private static IContainer _container;

        /// <summary>
        ///     Gets the main IoC container.
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (_container != null)
                    return _container;

                var builder = new ContainerBuilder();
                var assembly = Assembly.GetCallingAssembly();
                builder.RegisterApiControllers(assembly);
                builder.RegisterControllers(assembly);
                builder.RegisterModule<DependencyInjectionModule>();
                _container = builder.Build();
                return _container;
            }
        }

        /// <summary>
        ///     Resolves a bound instance.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The <see cref="T" />.</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}