﻿using Common.Logging;
using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;
using System.ServiceProcess;

namespace ERP.StockWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceContainer serviceContainer = new ServiceContainer();
            IServiceLocator serviceLocator = new LightInjectServiceLocator(serviceContainer);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            ServiceConfig.Register(serviceContainer);
#if DEBUG
            var service = new RegionService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServiceToRun;
            ServiceToRun = new ServiceBase[]
            {
                new RegionService()
            };
            ServiceBase.Run(ServiceToRun);
            //ServiceBase.Run(new RegionService());
#endif
        }
    }
}
