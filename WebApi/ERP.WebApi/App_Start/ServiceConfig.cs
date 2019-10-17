using AutoMapper;
using LightInject;

namespace ERP.WebApi
{
    public static class ServiceConfig
    {
        public static void Register(ServiceContainer serviceContainer)
        {
            Config(serviceContainer);
        }

        private static void Config(ServiceContainer serviceContainer)
        {
            RegisterMappers();
        }

        private static void RegisterMappers()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MapperConfig>();
            });

        }
    }
}
