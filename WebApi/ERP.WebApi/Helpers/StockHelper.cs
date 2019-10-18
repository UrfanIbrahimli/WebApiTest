using ERP.WebApi.MainDataContexts;
using ERP.WebApi.Models;
using ERP.WebApi.Response;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebApi.Helpers
{
    public static class StockHelper
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public static ActionResponse IncomePriceAdd(DS_IncomePrice dS_IncomePrice)
        {
            string Id = dS_IncomePrice.DS_StockID.Value + "" + dS_IncomePrice.ID;
            dS_IncomePrice.ID = Convert.ToDecimal(Id);
            try
            {
                var ctx = new MainDataContext();

                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<DS_IncomePrice>().Add(dS_IncomePrice);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_IncomePrice)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_IncomePrice)}), Exception: {ex.Message}");
                return ActionResponse.Failure(ex.Message);
            }
        }

        public static ActionResponse IncomePriceItemAdd(DS_IncomePriceItems dS_IncomePriceItems, decimal stockId)
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

        public static ActionResponse IncomePriceSimpleItemItemAdd(DS_IncomePriseSimpleItemItems dS_IncomePriseSimpleItemItems, decimal stockId, decimal incomePriceItemId)
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

        public static ActionResponse OutcomeAdd(DS_Outcome dS_Outcome)
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

        public static ActionResponse OutcomeItemAdd(DS_OutcomeItems dS_OutcomeItems, decimal stockId)
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