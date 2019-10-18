using AutoMapper;
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
        public static ActionResponse IncomePriceAdd(ERP.JobRunner.Models.DS_IncomePrice dS_IncomePrice)
        {
            string Id = Convert.ToInt32(dS_IncomePrice.DS_StockID.Value) + "" + Convert.ToInt32(dS_IncomePrice.ID);
            dS_IncomePrice.ID = Convert.ToDecimal(Id);

            foreach (var item in dS_IncomePrice.DS_IncomePriceItems)
            {
                string DS_IncomePriceID = Convert.ToInt32(dS_IncomePrice.DS_StockID) + "" + Convert.ToInt32(item.DS_IncomePriceID);
                string Idd = Convert.ToInt32(dS_IncomePrice.DS_StockID) + "" + Convert.ToInt32(item.ID);
                item.ID = Convert.ToDecimal(Idd);
                item.DS_IncomePriceID = Convert.ToDecimal(DS_IncomePriceID);
                item.DocDueDate = DateTime.Now;
                item.VHFDate = DateTime.Now;
            }

            dS_IncomePrice.CreateDate = DateTime.Now;
            dS_IncomePrice.DocDueDate = DateTime.Now;
            dS_IncomePrice.ContractDate = DateTime.Now;
            dS_IncomePrice.ExternalDocDate = DateTime.Now;
            dS_IncomePrice.IncomeDate = DateTime.Now;
            dS_IncomePrice.LastPaymentDate = DateTime.Now;
            dS_IncomePrice.OperationalDay = DateTime.Now;
            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<ERP.WebApi.Entity.DS_IncomePrice>(dS_IncomePrice);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<ERP.WebApi.Entity.DS_IncomePrice>().Add(model);
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

        public static ActionResponse IncomePriceItemAdd(ERP.JobRunner.Models.DS_IncomePriceItems dS_IncomePriceItems, decimal stockId)
        {
            //string DS_IncomePriceID = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriceItems.DS_IncomePriceID);
            //string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriceItems.ID);
            //dS_IncomePriceItems.ID = Convert.ToDecimal(Id);
            //dS_IncomePriceItems.DS_IncomePriceID = Convert.ToDecimal(DS_IncomePriceID);

            dS_IncomePriceItems.DS_IncomePriseSimpleItem.EnterDate = DateTime.Now;
            dS_IncomePriceItems.DocDueDate = DateTime.Now;
            dS_IncomePriceItems.OperationalDay = DateTime.Now;
            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<ERP.WebApi.Entity.DS_IncomePriceItems>(dS_IncomePriceItems);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<ERP.WebApi.Entity.DS_IncomePriceItems>().Add(model);
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

        public static ActionResponse IncomePriceSimpleItemItemAdd(ERP.JobRunner.Models.DS_IncomePriseSimpleItemItems dS_IncomePriseSimpleItemItems, decimal stockId, decimal incomePriceItemId)
        {
            string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriseSimpleItemItems.ID);
            dS_IncomePriseSimpleItemItems.ID = Convert.ToDecimal(Id);
            dS_IncomePriseSimpleItemItems.IdParent = incomePriceItemId;
            dS_IncomePriseSimpleItemItems.EnterDate = DateTime.Now;
            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<ERP.WebApi.Entity.DS_IncomePriseSimpleItemItems>(dS_IncomePriseSimpleItemItems);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<ERP.WebApi.Entity.DS_IncomePriseSimpleItemItems>().Add(model);
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

        public static ActionResponse OutcomeAdd(ERP.JobRunner.Models.DS_Outcome dS_Outcome)
        {
            string Id = Convert.ToInt32(dS_Outcome.DS_StockID.Value) + "" + Convert.ToInt32(dS_Outcome.ID);

            dS_Outcome.ID = Convert.ToDecimal(Id);

            //dS_Outcome.DS_OutcomeItems = null;
            foreach (var item in dS_Outcome.DS_OutcomeItems)
            {
                //string outcomeId = Convert.ToInt32(dS_Outcome.DS_StockID) + "" + Convert.ToInt32(dS_OutcomeItems.DS_OutcomeID);
                string Idd = Convert.ToInt32(dS_Outcome.DS_StockID) + "" + Convert.ToInt32(item.ID);
                item.ID = Convert.ToDecimal(Id);
                item.DS_OutcomeID = Convert.ToDecimal(Idd);
                item.DocDueDate = DateTime.Now;
                item.VHFDate = DateTime.Now;
            }
            dS_Outcome.CreateDate = DateTime.Now;
            dS_Outcome.DocDueDate = DateTime.Now;
            dS_Outcome.ExternalDocDate = DateTime.Now;
            dS_Outcome.OutcomeDate = DateTime.Now;
            dS_Outcome.OperationalDay = DateTime.Now;

            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<ERP.WebApi.Entity.DS_Outcome>(dS_Outcome);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<ERP.WebApi.Entity.DS_Outcome>().Add(model);
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

        public static ActionResponse OutcomeItemAdd(ERP.JobRunner.Models.DS_OutcomeItems dS_OutcomeItems, decimal stockId)
        {
            string outcomeId = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_OutcomeItems.DS_OutcomeID);
            string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_OutcomeItems.ID);

            dS_OutcomeItems.ID = Convert.ToDecimal(Id);
            dS_OutcomeItems.DS_OutcomeID = Convert.ToDecimal(outcomeId);
            dS_OutcomeItems.DocDueDate = DateTime.Now;
            dS_OutcomeItems.OperationalDay = DateTime.Now;

            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<ERP.WebApi.Entity.DS_OutcomeItems>(dS_OutcomeItems);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<ERP.WebApi.Entity.DS_OutcomeItems>().Add(model);
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