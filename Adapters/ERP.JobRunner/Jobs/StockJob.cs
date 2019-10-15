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
        public StockJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async void Execute(IJobExecutionContext context)
        {
            try
            {
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
