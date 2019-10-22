using Common.Logging;
using System;
using System.ServiceProcess;

namespace ERP.StockWindowsService
{
    partial class RegionService : ServiceBase
    {
        private readonly ILog _logger = LogManager.GetLogger<RegionService>();

        public RegionService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            _logger.Info($"OnDebug({string.Join(",", "OnDebug")})");
            OnStart(null);
        }
       
        protected override void OnStart(string[] args)
        {
            _logger.Info($"OnStart({string.Join(",", "Start")})");
            JobConfig.Start();
        }

        protected override void OnStop()
        {
            _logger.Info($"OnStop({string.Join(",", "Stop")})");
        }
    }
}
