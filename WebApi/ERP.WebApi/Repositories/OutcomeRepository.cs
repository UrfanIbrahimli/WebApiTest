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
    public class OutcomeRepository
    {
        private readonly ILogger _logger;
        public OutcomeRepository()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public ActionResponse Save(DS_Outcome dS_Outcome)
        {
            string Id = dS_Outcome.DS_StockID.Value + "" + dS_Outcome.ID;
            dS_Outcome.ID = Convert.ToDecimal(Id);
            try
            {
                var ctx = new MainDataContext();

                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<DS_Outcome>().Add(dS_Outcome);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_Outcome)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_Outcome)}), Exception: {ex.Message}");
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}