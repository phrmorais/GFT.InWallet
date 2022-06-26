using Flunt.Validations;
using GFT.InWallet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Validations
{
    public class AssetContract : Contract<Asset>
    {
        public AssetContract(Asset asset)
        {
            Requires()
            .IsNotNullOrEmpty(asset.Company, "Company", "Company Is Empty")
            .IsNotNullOrEmpty(asset.Symbol, "Symbol", "Symbol Is Empty");
        }



    }
}
