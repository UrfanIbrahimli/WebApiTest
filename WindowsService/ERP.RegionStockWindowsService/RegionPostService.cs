using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RegionStockWindowsService
{
    partial class RegionPostService : ServiceBase
    {
        private readonly ILog _logger = LogManager.GetLogger<RegionPostService>();

        public RegionPostService()
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
