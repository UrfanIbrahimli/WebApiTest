using ERP.StockWindowsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StockWindowsService.Repositories
{
    public interface IBaseRepository
    {
        List<DS_IncomePrice> GetIncomePriceList();
        List<DS_Outcome> GetOutcomeList();
    }
}
