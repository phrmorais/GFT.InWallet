using GFT.InWallet.Domain.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace GFT.InWallet.Business.YahooRequest
{
    public class GetInformation
    {
        public async Task<Data?> GetRealtimePrices(string symbol)
        {
            return (await "https://alpha.financeapi.net"
                .AppendPathSegment("market")
                .AppendPathSegment("get-realtime-prices")
                .SetQueryParam("symbols", symbol)
                .WithHeader("x-api-key", "rhjdrEKhxg75lU1Zqa0sNb1ILrz2462ELQIoWzi0")
                .GetJsonAsync<RealTimePrice>())
                .Data.FirstOrDefault();
        }
    }
}
