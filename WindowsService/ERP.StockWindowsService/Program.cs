using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
            ServiceBase.Run(new RegionService());
#endif
        }
    }
}
