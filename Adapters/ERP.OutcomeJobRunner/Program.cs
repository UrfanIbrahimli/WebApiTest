using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.OutcomeJobRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceContainer serviceContainer = new ServiceContainer();
            IServiceLocator serviceLocator = new LightInjectServiceLocator(serviceContainer);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            ServiceConfig.Register(serviceContainer);

#if DEBUG
            var service = new JobService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase.Run(new JobService());
#endif
        }
    }
}
