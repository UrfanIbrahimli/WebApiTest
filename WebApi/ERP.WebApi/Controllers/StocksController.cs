using ERP.WebApi.Models;
using System;
using System.Web.Http;

namespace ERP.WebApi.Controllers
{
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
