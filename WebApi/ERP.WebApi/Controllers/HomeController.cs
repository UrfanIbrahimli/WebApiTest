using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP.WebApi.ErpStockService;

namespace ERP.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        StockServiceClient serviceClient = new StockServiceClient();
        public IHttpActionResult Get()
        {
            var stockId_1 = serviceClient.GetIncomePriceList(1).ToList();
            var stockId_2 = serviceClient.GetIncomePriceList(2).ToList();
            var stockId_3 = serviceClient.GetIncomePriceList(3).ToList();
            var stockId_4 = serviceClient.GetIncomePriceList(4).ToList();
            var stockId_5 = serviceClient.GetIncomePriceList(5).ToList();
            return null;
        }
    }
}
