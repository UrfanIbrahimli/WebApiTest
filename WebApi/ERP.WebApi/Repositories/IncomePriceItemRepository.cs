using ERP.WebApi.MainDataContexts;
using ERP.WebApi.Models;
using ERP.WebApi.Response;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebApi.Repositories
{
    public class IncomePriceItemRepository
    {

        private readonly ILogger _logger;
        public IncomePriceItemRepository()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public ActionResponse Save(DS_IncomePriceItems dS_IncomePriceItems,decimal stockId)
        {
            string DS_IncomePriceID = stockId + "" + dS_IncomePriceItems.DS_IncomePriceID;
            dS_IncomePriceItems.DS_IncomePriceID = Convert.ToDecimal(DS_IncomePriceID);
            try
            {
                var ctx = new MainDataContext();

                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<DS_IncomePriceItems>().Add(dS_IncomePriceItems);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_IncomePriceItems)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_IncomePriceItems)}), Exception: {ex.Message}");
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}