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

namespace ERP.WebApi.Controllers
{
    public class StocksController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        StockServiceClient serviceClient = new StockServiceClient();
        public IHttpActionResult Get()
        {

            //81.21.85.119
            //var client = new HttpClient();
            //client.BaseAddress = new Uri("81.21.85.119");
            //HttpResponseMessage responseMessage = await client.GetAsync("");
            //string result = await responseMessage.Content.ReadAsStringAsync();

            logger.Log(LogLevel.Info,"successfull");
            var incomePrice_stockId_1 = serviceClient.GetIncomePriceList(1).ToList();
            var incomePrice_stockId_2 = serviceClient.GetIncomePriceList(2).ToList();

            var outCome_stock_1 = serviceClient.GetOutcomeList(1).ToList();
            var outCome_stock_2 = serviceClient.GetOutcomeList(1).ToList();
            var ok  = JsonConvert.SerializeObject(incomePrice_stockId_1);
            return Ok(ok);
        }
    }
}
