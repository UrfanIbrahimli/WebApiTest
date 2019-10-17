using ERP.WebApi.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP.WebApi.Helpers;
using AutoMapper;

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
                var incomeList = Mapper.Map<List<DS_IncomePrice>>(common.dS_IncomePrices);
                var outcomeList = Mapper.Map<List<DS_Outcome>>(common.dS_Outcomes);
                InsertHelper.IncomePrice(incomeList);
                InsertHelper.Outome(outcomeList);
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
