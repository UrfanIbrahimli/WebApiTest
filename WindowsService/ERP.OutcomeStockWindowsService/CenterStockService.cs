using Common.Logging;
using System.ServiceProcess;

namespace ERP.OutcomeStockWindowsService
{
    partial class CenterStockService : ServiceBase
    {
        private readonly ILog _logger = LogManager.GetLogger<CenterStockService>();
        public CenterStockService()
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
