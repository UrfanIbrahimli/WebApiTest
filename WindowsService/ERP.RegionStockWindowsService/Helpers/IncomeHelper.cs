using AutoMapper;
using ERP.RegionStockWindowsService.Entities;
using ERP.RegionStockWindowsService.Response;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.RegionStockWindowsService.Helpers
{
    public static class IncomeHelper
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public static ActionResponse IncomePriceAdd(DS_IncomePrice dS_IncomePrice)
        {
            string Id = 7 + "" + Convert.ToInt32(dS_IncomePrice.ID);
            dS_IncomePrice.ID = Convert.ToDecimal(Id);
            dS_IncomePrice.StatusID = 20284;
            dS_IncomePrice.OwnerID = 12;
            dS_IncomePrice.BranchID = 1;
            dS_IncomePrice.CurrencyID = 6;
            dS_IncomePrice.CustomerID = 38375;
            dS_IncomePrice.ExternalDocNumber = Id;
            dS_IncomePrice.PhysicalPersonID = 38375;
            dS_IncomePrice.DS_StockID = 7;
            dS_IncomePrice.RefIncomeTypeID = 1;
            dS_IncomePrice.DsPaymentTypeID = 1;


            foreach (var item in dS_IncomePrice.DS_IncomePriceItems)
            {
                string Idd = Convert.ToInt32(dS_IncomePrice.DS_StockID) + "" + Convert.ToInt32(item.ID);
                item.ID = Convert.ToDecimal(Idd);
                item.DS_IncomePriceID = Convert.ToDecimal(dS_IncomePrice.ID);
                //item.Quantity = 1;
                item.Price = 1;
                item.VatID = 3;
            }

            try
            {
                var ctx = new DataContext();
                //var model = Mapper.Map<ERP.WebApi.Entity.DS_IncomePrice>(dS_IncomePrice);
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



        public static ActionResponse IncomePriceSimpleItemItemAdd(DS_IncomePriceItems dS_IncomePriceItems, decimal stockId, decimal incomePriceItemId)
        {
            var dS_IncomePriseSimpleItemItems = Mapper.Map<DS_IncomePriseSimpleItemItems>(dS_IncomePriceItems);
            string Id = Convert.ToInt32(stockId) + "" + Convert.ToInt32(dS_IncomePriseSimpleItemItems.ID);
            dS_IncomePriseSimpleItemItems.ID = Convert.ToDecimal(Id);
            dS_IncomePriseSimpleItemItems.IdParent = incomePriceItemId;
            dS_IncomePriseSimpleItemItems.Moisture = 18;
            dS_IncomePriseSimpleItemItems.IsFirst = true;

            try
            {
                var ctx = new DataContext();
                //var model = Mapper.Map<DS_IncomePriseSimpleItemItems>(dS_IncomePriseSimpleItemItems);
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