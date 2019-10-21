using ERP.OutcomeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.OutcomeWebApi.Controllers
{
    public class IncomepricesController : BaseController
    {
       
        [HttpPost]
        public IHttpActionResult IncomePrice([FromBody] List<DS_Outcome> dS_Outcome)
        {
            Create(dS_Outcome);
            return Ok(dS_Outcome);
        }
    }
}
