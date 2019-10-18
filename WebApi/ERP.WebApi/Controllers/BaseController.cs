using ERP.WebApi.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ERP.WebApi.Helpers;

namespace ERP.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ILogger _logger;
        public BaseController()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        [NonAction]
        protected bool Create(CommonModel common)
        {
            try
            {
                //var incomePriceList = Mapper.Map<List<DS_IncomePrice>>(common.dS_IncomePrices);
                //var outcomeList = Mapper.Map<List<DS_Outcome>>(common.dS_Outcomes);

                //foreach (var incomePrice in incomePriceList)
                //{
                //    StockHelper.IncomePriceAdd(incomePrice);
                //    foreach (var incomePriceItem in incomePrice.DS_IncomePriceItems)
                //    {
                //        StockHelper.IncomePriceItemAdd(incomePriceItem, incomePrice.DS_StockID.Value);
                //        StockHelper.IncomePriceSimpleItemItemAdd(incomePriceItem.DS_IncomePriseSimpleItem, incomePrice.DS_StockID.Value, incomePriceItem.ID);
                //    }
                //}

                //foreach (var outcome in outcomeList)
                //{
                //    StockHelper.OutcomeAdd(outcome);
                //    foreach (var outcomeItem in outcome.DS_OutcomeItems)
                //    {
                //        StockHelper.OutcomeItemAdd(outcomeItem, outcome.DS_StockID.Value);
                //    }
                //}

                _logger.Info($"Create({string.Join(",",true)})");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Create({string.Join(",", false)}), Exception: {ex.Message}");
                return false;
            }
            
        }
    }
}
