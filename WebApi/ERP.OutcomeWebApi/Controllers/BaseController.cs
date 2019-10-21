using AutoMapper;
using ERP.OutcomeWebApi.Entities;
using ERP.OutcomeWebApi.Helpers;
using ERP.OutcomeWebApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.OutcomeWebApi.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ILogger _logger;
        public BaseController()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        [NonAction]
        protected bool Create(List<DS_Outcome> dS_Outcome)
        {
            try
            {
                var incomeList = Mapper.Map<List<DS_IncomePrice>>(dS_Outcome);
                foreach (var incomePrice in incomeList)
                {
                    IncomeHelper.IncomePriceAdd(incomePrice);
                    foreach (var incomePriceItem in incomePrice.DS_IncomePriceItems)
                    {
                        IncomeHelper.IncomePriceSimpleItemItemAdd(incomePriceItem, incomePrice.DS_StockID.Value, incomePriceItem.ID);
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
