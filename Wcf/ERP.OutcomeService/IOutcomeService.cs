using ERP.OutcomeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ERP.OutcomeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOutcomeService" in both code and config file together.
    [ServiceContract]
    public interface IOutcomeService
    {
        [OperationContract]
        List<DS_Outcome> GetOutcomeList();
    }
}
