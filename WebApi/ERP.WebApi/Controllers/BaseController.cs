using ERP.WebApi.ErpStockService;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ILogger _logger;
        private readonly StockServiceClient _serviceClient;
        public BaseController()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _serviceClient = new StockServiceClient();
        }
        public bool Stocks()
        {
            try
            {
                //IncomePrice
                var incomePrice_stockId_1 = _serviceClient.GetIncomePriceList(1).ToList();
                var incomePrice_stockId_2 = _serviceClient.GetIncomePriceList(2).ToList();

                //OutcomePrice
                var outCome_stock_1 = _serviceClient.GetOutcomeList(1).ToList();
                var outCome_stock_2 = _serviceClient.GetOutcomeList(2).ToList();
                _logger.Info($"Stocks({string.Join(",",true)})");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Stocks({string.Join(",", false)}), Exception: {ex.Message}");
                return false;
            }
            
        }
    }
}
