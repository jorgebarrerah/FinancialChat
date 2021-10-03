using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockService;
using System.Threading.Tasks;
namespace TestChat
{
    [TestClass]
    public class ChatTests
    {
        [TestMethod]
        public async Task TestGetStock_WithValidStockCode()
        {
            StockService.Controllers.StockController service = new StockService.Controllers.StockController();

            string stockCode = "wig";
            string stockMessage = string.Empty;
            stockMessage = await service.GetStock(stockCode);
            // If result contains per share is a valid response for this case.
            Assert.IsTrue(stockMessage.Contains("per share"), "TestGetStock_WithValidStockCode not successful.");

        }


        [TestMethod]
        public async Task TestGetStock_WithEmptyStockCode()
        {
            StockService.Controllers.StockController service = new StockService.Controllers.StockController();

            string stockCode = "";
            string stockMessage = string.Empty;
            stockMessage = await service.GetStock(stockCode);
            // If result not contain per share is a valid response for this case.
            Assert.IsTrue(!stockMessage.Contains("per share"), "TestGetStock_WithEmptyStockCode not successful.");

        }

        [TestMethod]
        public async Task TestGetStock_WithInvalidStockCode()
        {
            StockService.Controllers.StockController service = new StockService.Controllers.StockController();

            string stockCode = "xyz";
            string stockMessage = string.Empty;
            stockMessage = await service.GetStock(stockCode);
            // If result not contain per share is a valid response for this case.
            Assert.IsTrue(!stockMessage.Contains("per share"), "TestGetStock_WithInvalidStockCode not successful.");

        }
    }
}
