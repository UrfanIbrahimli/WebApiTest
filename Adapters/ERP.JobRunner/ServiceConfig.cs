using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.JobRunner.Mapping;
using LightInject;

namespace ERP.JobRunner
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
