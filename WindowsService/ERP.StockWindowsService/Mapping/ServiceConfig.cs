using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using ERP.StockWindowsService.Mapping;

namespace ERP.StockWindowsService
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
