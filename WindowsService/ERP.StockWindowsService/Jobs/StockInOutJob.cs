using AutoMapper;
using Common.Logging;
using ERP.StockWindowsService.Repositories;
using ERP.WebApi.Models;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StockWindowsService.Jobs
{
    public class StockInOutJob : IJob
    {
        private readonly HttpClient _client;
        private readonly ILog _logger;
        private readonly BaseRepository _serviceClient;
        public StockInOutJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetLogger<StockInOutJob>();
            _serviceClient = new BaseRepository();
            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiUrl"]);
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
                _logger.Error($"Execute({string.Join(",", new { context.JobDetail,context.Result})}), Exception: {ex.Message}");
                _logger.Error("ExceptionMain", ex);
            }

        }
    }
}
