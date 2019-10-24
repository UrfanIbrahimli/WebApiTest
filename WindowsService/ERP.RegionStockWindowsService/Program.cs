using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RegionStockWindowsService
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
            var service = new RegionPostService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServiceToRun;
            ServiceToRun = new ServiceBase[]
            {
                new RegionPostService()
            };
            ServiceBase.Run(ServiceToRun);
#endif
        }
    }
}
