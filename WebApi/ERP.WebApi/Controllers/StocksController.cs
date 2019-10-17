using ERP.WebApi.Models;
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
        [HttpPost]
        public IHttpActionResult SaveData([FromBody] CommonModel common)
        {
            Create(common);
            return Ok(common);
        }
    }
}
