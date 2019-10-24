using ERP.GetOutcomeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.GetOutcomeWebApi.Repositories
{
    public interface IBaseRepository
    {
        List<DS_Outcome> GetOutcomeList();
    }
}
