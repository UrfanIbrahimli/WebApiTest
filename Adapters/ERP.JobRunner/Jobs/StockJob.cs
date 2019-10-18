using ERP.JobRunner.Models;
using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AutoMapper;

namespace ERP.JobRunner.Jobs
{
    public class StockJob : IJob
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly StockService.StockServiceClient _serviceClient;
        public StockJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetCurrentClassLogger();
            _serviceClient = new StockService.StockServiceClient();
        }
        public async void Execute(IJobExecutionContext context)
        {
            try
            {
                var incomeStock = _serviceClient.GetIncomePriceList().ToList();
                var outcomeStock = _serviceClient.GetOutcomeList().ToList();
                var incomeList = Mapper.Map<List<DS_IncomePrice>>(incomeStock);
                var outcomelist = Mapper.Map<List<DS_Outcome>>(outcomeStock);

                var common = new CommonModel()
                {
                    dS_IncomePrices = incomeList,
                    dS_Outcomes = outcomelist
                };

                _client.BaseAddress = new Uri("http://localhost:62998/");

                var commonContent = JsonConvert.SerializeObject(common);

                var content = new StringContent(commonContent, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await _client.GetAsync("api/stocks/");
                HttpResponseMessage response = await _client.PostAsync("api/stocks/SaveData", content);

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
