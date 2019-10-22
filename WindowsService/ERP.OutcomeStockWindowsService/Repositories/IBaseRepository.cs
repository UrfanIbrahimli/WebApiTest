using ERP.OutcomeStockWindowsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.OutcomeStockWindowsService.Repositories
{
    public interface IBaseRepository
    {
        List<DS_Outcome> GetOutcomeList();
    }
}
