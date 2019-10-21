using AutoMapper;
using ERP.StockWindowsService.Repositories;
using ERP.WebApi.Models;
using Newtonsoft.Json;
using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StockWindowsService.Jobs
{
    public class StockInOutJob : IJob
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly BaseRepository _serviceClient;
        public StockInOutJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetCurrentClassLogger();
            _serviceClient = new BaseRepository();
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
