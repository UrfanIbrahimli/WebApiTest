using NLog;
using Quartz;
using System;
using System.Linq;
using System.Net.Http;

namespace ERP.JobRunner.Jobs
{
    public class StockJob : IJob
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly ERP1.StockService.StockServiceClient _serviceClient;
        public StockJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetCurrentClassLogger();
            _serviceClient = new ERP1.StockService.StockServiceClient();
        }
        public async void Execute(IJobExecutionContext context)
        {
            try
            {
                var stockId_1 = _serviceClient.GetIncomePriceList(1);
                _client.BaseAddress = new Uri("http://localhost:62998/");
                HttpResponseMessage response = await _client.GetAsync("api/stocks");
                if (response.IsSuccessStatusCode)
                {
                    _logger.Info($"Execute({string.Join(",", context)})");
                    string result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Execute({string.Join(",", context)}), Exception: {ex.Message}");
            }

        }
    }
}
