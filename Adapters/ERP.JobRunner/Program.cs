using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.JobRunner
{
    class Program
    {
        static void Main(string[] args)
        {

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
