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
    public class AssetIntegration
    {
        public readonly HttpClient _client;

        public AssetIntegration()
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
        [Fact]
        public async Task PostAsset()
        {
            var jsonContent = JsonConvert.SerializeObject(new Asset { Symbol = "teste", Company = "Apple Inc" });
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Asset", contentString);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task GetAsset()
        {
            var response = await _client.GetStringAsync("/Asset");
            var asset = JsonConvert.DeserializeObject<List<Asset>>(response);
            Assert.NotNull(asset);
        }
        [Fact]
        public async Task GetAssetBySymbol()
        {
            var response = await _client.GetStringAsync("/Asset/teste");
            var asset = JsonConvert.DeserializeObject<Asset>(response);
            Assert.NotNull(asset);
        }
        [Fact]
        public async Task Delete()
        {
            var response = await _client.DeleteAsync("/Asset/teste");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
