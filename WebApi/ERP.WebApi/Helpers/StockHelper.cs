using AutoMapper;
using Common.Logging;
using ERP.WebApi.Models;
using ERP.WebApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebApi.Helpers
{
    public class StockHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger<StockHelper>();
        public static ActionResponse IncomePriceAdd(DS_IncomePrice dS_IncomePrice)
        {
            string Id = Convert.ToInt32(dS_IncomePrice.DS_StockID.Value) + "" + Convert.ToInt32(dS_IncomePrice.ID);
            dS_IncomePrice.ID = Convert.ToDecimal(Id);

            foreach (var item in dS_IncomePrice.DS_IncomePriceItems)
            {
                string DS_IncomePriceID = Convert.ToInt32(dS_IncomePrice.DS_StockID) + "" + Convert.ToInt32(item.DS_IncomePriceID);
                string Idd = Convert.ToInt32(dS_IncomePrice.DS_StockID) + "" + Convert.ToInt32(item.ID);
                item.ID = Convert.ToDecimal(Idd);
            }

            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<Entity.DS_IncomePrice>(dS_IncomePrice);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<Entity.DS_IncomePrice>().Add(model);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_IncomePrice.ID)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_IncomePrice.ID)}), Exception: {ex}");
                return ActionResponse.Failure(ex.Message);
            }
        }

        

        public static ActionResponse IncomePriceSimpleItemItemAdd(DS_IncomePriseSimpleItemItems dS_IncomePriseSimpleItemItems, decimal stockId, decimal incomePriceItemId)
        {
            string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriseSimpleItemItems.ID);
            dS_IncomePriseSimpleItemItems.ID = Convert.ToDecimal(Id);
            dS_IncomePriseSimpleItemItems.IdParent = incomePriceItemId;

            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<Entity.DS_IncomePriseSimpleItemItems>(dS_IncomePriseSimpleItemItems);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<Entity.DS_IncomePriseSimpleItemItems>().Add(model);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_IncomePriseSimpleItemItems.ID)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_IncomePriseSimpleItemItems.ID)}), Exception: {ex}");
                return ActionResponse.Failure(ex.Message);
            }
        }

        public static ActionResponse OutcomeAdd(DS_Outcome dS_Outcome)
        {
            string Id = Convert.ToInt32(dS_Outcome.DS_StockID.Value) + "" + Convert.ToInt32(dS_Outcome.ID);
            dS_Outcome.ID = Convert.ToDecimal(Id);

            foreach (var item in dS_Outcome.DS_OutcomeItems)
            {
                string Idd = Convert.ToInt32(dS_Outcome.DS_StockID.Value) + "" + Convert.ToInt32(item.ID);
                item.ID = Convert.ToDecimal(Idd);
                item.DS_OutcomeID = Convert.ToDecimal(Id);
                item.QualityID = Convert.ToDecimal(5);
            }

            try
            {
                var ctx = new MainDataContext();
                var model = Mapper.Map<Entity.DS_Outcome>(dS_Outcome);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Set<Entity.DS_Outcome>().Add(model);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    _logger.Info($"Save({string.Join(",", dS_Outcome.ID)})");
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Save({string.Join(",", dS_Outcome.ID)}), Exception: {ex}");
                return ActionResponse.Failure(ex.Message);
            }
        }

        //public static ActionResponse OutcomeItemAdd(DS_OutcomeItems dS_OutcomeItems, decimal stockId)
        //{
        //    string outcomeId = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_OutcomeItems.DS_OutcomeID);
        //    string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_OutcomeItems.ID);

        //    dS_OutcomeItems.ID = Convert.ToDecimal(Id);
        //    dS_OutcomeItems.QualityID = 5;
        //    dS_OutcomeItems.DS_OutcomeID = Convert.ToDecimal(outcomeId);

        //    try
        //    {
        //        var ctx = new MainDataContext();
        //        var model = Mapper.Map<Entity.DS_OutcomeItems>(dS_OutcomeItems);
        //        using (var transaction = ctx.Database.BeginTransaction())
        //        {
        //            ctx.Set<Entity.DS_OutcomeItems>().Add(model);
        //            var result = ctx.SaveChanges();
        //            transaction.Commit();
        //            _logger.Info($"Save({string.Join(",", dS_OutcomeItems.ID)})");
        //            return ActionResponse.Succeed();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error($"Save({string.Join(",", dS_OutcomeItems.ID)}), Exception: {ex}");
        //        return ActionResponse.Failure(ex.Message);
        //    }
        //}




        //public static ActionResponse IncomePriceItemAdd(ERP.JobRunner.Models.DS_IncomePriceItems dS_IncomePriceItems, decimal stockId)
        //{
        //    string DS_IncomePriceID = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriceItems.DS_IncomePriceID);
        //    string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriceItems.ID);
        //    dS_IncomePriceItems.ID = Convert.ToDecimal(Id);
        //    dS_IncomePriceItems.DS_IncomePriceID = Convert.ToDecimal(DS_IncomePriceID);

        //    try
        //    {
        //        var ctx = new MainDataContext();
        //        var model = Mapper.Map<ERP.WebApi.Entity.DS_IncomePriceItems>(dS_IncomePriceItems);
        //        using (var transaction = ctx.Database.BeginTransaction())
        //        {
        //            ctx.Set<ERP.WebApi.Entity.DS_IncomePriceItems>().Add(model);
        //            var result = ctx.SaveChanges();
        //            transaction.Commit();
        //            _logger.Info($"Save({string.Join(",", dS_IncomePriceItems)})");
        //            return ActionResponse.Succeed();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error($"Save({string.Join(",", dS_IncomePriceItems)}), Exception: {ex.Message}");
        //        return ActionResponse.Failure(ex.Message);
        //    }
        //}

    }
}