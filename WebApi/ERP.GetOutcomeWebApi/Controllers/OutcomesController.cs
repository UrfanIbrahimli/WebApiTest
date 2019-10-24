using ERP.GetOutcomeWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.GetOutcomeWebApi.Controllers
{
    public class OutcomesController : ApiController
    {
        private readonly BaseRepository _baseRepository;
        public OutcomesController()
        {
            _baseRepository = new BaseRepository();
        }

        [HttpGet]
        public IHttpActionResult GetOutcome()
        {
            var x = _baseRepository.GetOutcomeList();
            return Ok(x);
        }
    }
}
