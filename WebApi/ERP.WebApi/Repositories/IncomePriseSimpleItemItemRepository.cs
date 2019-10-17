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
    public class IncomePriseSimpleItemItemRepository
    {
        private readonly ILogger _logger;
        public IncomePriseSimpleItemItemRepository()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public ActionResponse Save(DS_IncomePriseSimpleItemItems dS_IncomePriseSimpleItemItems,decimal stockId,decimal incomePriceItemId)
        {
            string IdParent = stockId + "" + incomePriceItemId;
            dS_IncomePriseSimpleItemItems.IdParent = Convert.ToDecimal(IdParent);

            try
            {
                var ctx = new MainDataContext();

                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<DS_IncomePriseSimpleItemItems>().Add(dS_IncomePriseSimpleItemItems);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_IncomePriseSimpleItemItems)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_IncomePriseSimpleItemItems)}), Exception: {ex.Message}");
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}