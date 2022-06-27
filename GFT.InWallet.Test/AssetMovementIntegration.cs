using GFT.InWallet.Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Test
{
    public class AssetMovementMovimentIntegration
    {
        public readonly HttpClient _client;

        public AssetMovementMovimentIntegration()
        {
            var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // set up servises
                });
            });
            _client = application.CreateClient();
        }
        [Theory]
        [InlineData("AAPL", 'C', 50)]
        [InlineData("AAPL", 'V', 30)]
        [InlineData("AAPL", 'C', 10)]
        [InlineData("AAPL", 'V', 8)]
        [InlineData("AAPL", 'V', 11)]
        [InlineData("AAPL", 'C', 22)]
        public async Task PostAssetMovement(string symbol, char operationType, double volume)
        {
            var jsonContent = JsonConvert.SerializeObject(new AssetMovement
            {
                Symbol = symbol,
                OperationDate = DateTime.Now,
                OperationType = operationType,
                Volume = volume
            });
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/AssetMovement", contentString);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task GetAssetMovement()
        {
            var response = await _client.GetStringAsync("/AssetMovement");
            var AssetMovement = JsonConvert.DeserializeObject<List<AssetMovement>>(response);
            Assert.NotNull(AssetMovement);
        }
        [Fact]
        public async Task GetAssetMovementBySymbol()
        {
            var response = await _client.GetStringAsync("/AssetMovement/teste");
            var AssetMovement = JsonConvert.DeserializeObject<AssetMovement>(response);
            Assert.NotNull(AssetMovement);
        }
        [Fact]
        public async Task GetDelete()
        {
            var response = await _client.GetAsync("/AssetMovement/teste");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
