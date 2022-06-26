using Flunt.Validations;
using GFT.InWallet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Validations
{
    public class AssetMovementContract : Contract<AssetMovement>
    {
        public AssetMovementContract(AssetMovement assetMovement)
        {
            Requires()
            .IsNotNullOrEmpty(assetMovement.Symbol, "Symbol", "Symbol Is Empty");
        }



    }
}
