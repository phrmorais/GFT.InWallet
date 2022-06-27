using GFT.InWallet.Business.Core;
using GFT.InWallet.Business.YahooRequest;
using GFT.InWallet.Domain.Entity;
using Xunit;

namespace GFT.InWallet.Test
{
    public class GetPricesTest
    {
        [Fact]
        public async Task GetRealtimePrices()
        {
            var getInformation = new GetInformation();
            var data = await getInformation.GetRealtimePrices("AAPL");
            Assert.NotNull(data);
        }
        [Fact]
        public async Task GetCotation()
        {

            var movement = new AssetMovement
            {
                Symbol = "AAPL",
                OperationType = 'V',
                Volume = 50
            };
            await movement.GetCotation();
            Assert.NotEqual(0, movement.Total);
        }
    }
}