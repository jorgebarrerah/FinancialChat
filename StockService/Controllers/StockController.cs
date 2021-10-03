using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;


namespace StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // Call stooq.com API
        [HttpGet]
        public async Task<string> GetStock(string stockCode)
        {
            string message = "{0} quote is ${1} per share";
            string apiResult = string.Empty;
            string[] result = new string[2];
            string stockName = string.Empty;
            string stockValue = string.Empty;
            try
            {
                
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();

                apiResult = await client.GetStringAsync($"https://stooq.com/q/l/?s=" + stockCode + "&f=sc&h&e=csv");

                result = apiResult.Split('\n');

                stockName = result[1].Split(',')[0];
                stockValue = result[1].Split(',')[1].Replace('\r', ' ').Trim();

                if (stockValue == "N/D") message = "There is no definition for " + stockCode;
                else message = string.Format(message, stockName, stockValue);


            }
            catch (Exception)
            {
                message = "Stock service could not resolve the request.";
            }

            return message;
        }
    }
}
