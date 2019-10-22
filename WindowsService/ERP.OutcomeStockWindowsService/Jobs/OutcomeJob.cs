using AutoMapper;
using ERP.OutcomeStockWindowsService.Repositories;
using ERP.OutcomeWebApi.Models;
using Newtonsoft.Json;
using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.OutcomeStockWindowsService.Jobs
{
    public class OutcomeJob : IJob
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly BaseRepository _serviceClient;
        public OutcomeJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetCurrentClassLogger();
            _serviceClient = new BaseRepository();
            _client.BaseAddress = new Uri("http://localhost:64297/");
        }
        public async void Execute(IJobExecutionContext context)
        {
            try
            {
                var outcomeStock = _serviceClient.GetOutcomeList().ToList();
                var outcomelist = Mapper.Map<List<DS_Outcome>>(outcomeStock);
                var commonContent = JsonConvert.SerializeObject(outcomelist);

                var content = new StringContent(commonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync("api/incomeprices/IncomePrice", content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.Info($"Execute({string.Join(",", response.IsSuccessStatusCode)})");
                }
                else
                {
                    _logger.Error($"Execute({string.Join(",", response.IsSuccessStatusCode)})");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Execute({string.Join(",", context)}), Exception: {ex.Message}");
            }

        }
    }
}
