using GFT.InWallet.Business.YahooRequest;
using GFT.InWallet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Business.Core
{
    public static class AssetsNegotiation
    {
        public static async Task GetCotation(this AssetMovement assetMovement)
        {
            if (!assetMovement.IsValid) return;
            var cotation = await (new GetInformation()).GetRealtimePrices(assetMovement.Symbol ?? "");
            if (cotation.attributes.last is null)
            {
                assetMovement.AddNotification("Symbol", "Symbol not exists");
                return;
            }
            assetMovement.PriceAsset = cotation.attributes.last ?? 0;
            assetMovement.Total = assetMovement.Volume * cotation.attributes.last ?? 0;
            assetMovement.Fee = (assetMovement.Total * 0.0325) / 100;
            assetMovement.Total += assetMovement.Fee + 5;

        }
    }
}
