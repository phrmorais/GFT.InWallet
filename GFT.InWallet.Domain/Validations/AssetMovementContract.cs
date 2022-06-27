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
            .IsNotNullOrEmpty(assetMovement.Symbol, "Symbol", "Symbol Is Empty")
            .IsNotNull(assetMovement.OperationDate, "OperationDate", "Date is null")
            .IsGreaterOrEqualsThan(assetMovement.Volume, 0, "Volume", "volume must be greater than zero");
            char[] chars = { 'C', 'V' };
            if (!chars.Contains(assetMovement.OperationType))
                assetMovement.AddNotification("OperationType", "Operation type must be V or C");
        }



    }
}
