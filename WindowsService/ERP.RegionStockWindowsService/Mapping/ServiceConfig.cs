using AutoMapper;
using ERP.RegionStockWindowsService.Mapping;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RegionStockWindowsService
{
    public class ServiceConfig
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
