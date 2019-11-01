using AutoMapper;
using Common.Logging;
using ERP.WebApi.Helpers;
using ERP.WebApi.Models;
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
        private readonly ILog _logger;
        public BaseController()
        {
            _logger = LogManager.GetLogger<BaseController>();
        }

        [NonAction]
        protected bool Create(CommonModel common)
        {
            try
            {
                var incomePriceList = common.dS_IncomePrices;
                var outcomeList = common.dS_Outcomes;

                if(incomePriceList.Count() != 0)
                {
                    foreach (var incomePrice in incomePriceList)
                    {
                        StockHelper.IncomePriceAdd(incomePrice);
                        foreach (var incomePriceItem in incomePrice.DS_IncomePriceItems)
                        {
                            StockHelper.IncomePriceSimpleItemItemAdd(incomePriceItem.DS_IncomePriseSimpleItem, incomePrice.DS_StockID.Value, incomePriceItem.ID);
                        }
                    }
                }

                if (outcomeList.Count() != 0)
                {
                    foreach (var outcome in outcomeList)
                    {

                        StockHelper.OutcomeAdd(outcome);

                        //foreach (var outcomeItem in outcome.DS_OutcomeItems)
                        //{
                        //    StockHelper.OutcomeItemAdd(outcomeItem, outcome.DS_StockID.Value);
                        //}
                    }
                }
                

                _logger.Info($"Create({string.Join(",", true)})");
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
