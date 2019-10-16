using ERP.WebApi.ErpStockService;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ERP.WebApi.Controllers
{
    //81.21.85.119
    public class StocksController : BaseController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Get()
        {
            if (!Stocks())
                return BadRequest();
            return Ok();
        }
    }
}
