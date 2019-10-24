using AutoMapper;
using Common.Logging;
using ERP.OutcomeWebApi.Models;
using ERP.RegionStockWindowsService.Entities;
using ERP.RegionStockWindowsService.Helpers;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RegionStockWindowsService.Jobs
{
    public class OutcomeToIncomeJob : IJob
    {
        private readonly HttpClient _client;
        private readonly ILog _logger;
        public OutcomeToIncomeJob()
        {
            _client = new HttpClient();
            _logger = LogManager.GetLogger<OutcomeToIncomeJob>();
            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiUrl"]);
        }
        public async void Execute(IJobExecutionContext context)
        {
            try
            {
                HttpResponseMessage response =  _client.GetAsync("api/outcomes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var outcomeContent = await response.Content.ReadAsStringAsync();
                    var outcomeList = JsonConvert.DeserializeObject<List<DS_Outcome>>(outcomeContent);

                    var incomeList = Mapper.Map<List<DS_IncomePrice>>(outcomeList);
                    foreach (var incomePrice in incomeList)
                    {
                        IncomeHelper.IncomePriceAdd(incomePrice);
                        foreach (var incomePriceItem in incomePrice.DS_IncomePriceItems)
                        {
                            IncomeHelper.IncomePriceSimpleItemItemAdd(incomePriceItem, incomePrice.DS_StockID.Value, incomePriceItem.ID);
                        }
                    }

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
