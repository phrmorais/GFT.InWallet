using GFT.InWallet.Business.YahooRequest;
using GFT.InWallet.Domain.Entity;
using Xunit;

namespace GFT.InWallet.Test
{
    public class GetPricesTest
    {
        [Fact]
        public async Task Test1Async()
        {
            var getInformation = new GetInformation();
            var data = await getInformation.GetRealtimePrices("AAPL");
            Assert.NotNull(data);
        }
    }
}