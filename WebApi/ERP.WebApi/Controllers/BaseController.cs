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
using ERP.WebApi.Repositories;

namespace ERP.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IncomePriceRepository _incomePriceRepository;
        private readonly IncomePriceItemRepository _incomePriceItemRepository;
        private readonly IncomePriseSimpleItemItemRepository _incomePriseSimpleItemItemRepository;
        private readonly OutcomeRepository _outcomeRepository;
        private readonly OutcomeItemRepository _outcomeItemRepository;

        public BaseController()
        {
            _incomePriceRepository = new IncomePriceRepository();
            _incomePriceItemRepository = new IncomePriceItemRepository();
            _incomePriseSimpleItemItemRepository = new IncomePriseSimpleItemItemRepository();
            _outcomeRepository = new OutcomeRepository();
            _outcomeItemRepository = new OutcomeItemRepository();
            _logger = LogManager.GetCurrentClassLogger();
        }

        [NonAction]
        protected bool Create(CommonModel common)
        {
            try
            {
                var incomePriceList = Mapper.Map<List<DS_IncomePrice>>(common.dS_IncomePrices);
                var outcomeList = Mapper.Map<List<DS_Outcome>>(common.dS_Outcomes);

                foreach (var incomePrice in incomePriceList)
                {
                    _incomePriceRepository.Save(incomePrice);
                    foreach (var incomePriceItem in incomePrice.DS_IncomePriceItems)
                    {
                        _incomePriceItemRepository.Save(incomePriceItem, incomePrice.DS_StockID.Value);
                        _incomePriseSimpleItemItemRepository.Save(incomePriceItem.DS_IncomePriseSimpleItem, incomePrice.DS_StockID.Value, incomePriceItem.ID);
                    }
                }

                foreach (var outcome in outcomeList)
                {
                    _outcomeRepository.Save(outcome);
                    foreach (var outcomeItem in outcome.DS_OutcomeItems)
                    {
                        _outcomeItemRepository.Save(outcomeItem,outcome.DS_StockID.Value);
                    }
                }
            
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
