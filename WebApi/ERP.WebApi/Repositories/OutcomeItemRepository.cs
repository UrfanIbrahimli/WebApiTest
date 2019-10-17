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
    public class OutcomeItemRepository
    {
        private readonly ILogger _logger;
        public OutcomeItemRepository()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public ActionResponse Save(DS_OutcomeItems dS_OutcomeItems,decimal stockId)
        {
            string outcomeId = stockId + "" + dS_OutcomeItems.DS_OutcomeID;
            dS_OutcomeItems.DS_OutcomeID = Convert.ToDecimal(outcomeId);

            try
            {
                var ctx = new MainDataContext();

                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<DS_OutcomeItems>().Add(dS_OutcomeItems);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_OutcomeItems)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_OutcomeItems)}), Exception: {ex.Message}");
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}