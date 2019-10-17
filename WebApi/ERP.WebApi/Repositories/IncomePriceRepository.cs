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
    public class IncomePriceRepository
    {
        private readonly ILogger _logger;
        public IncomePriceRepository()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public ActionResponse Save(DS_IncomePrice  dS_IncomePrice)
        {
            string Id = dS_IncomePrice.DS_StockID.Value+ "" + dS_IncomePrice.ID;
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
    }
}