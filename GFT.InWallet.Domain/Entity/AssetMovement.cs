using GFT.InWallet.Domain.Enumerated;
using GFT.InWallet.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Entity
{
    public class AssetMovement : BaseEntity
    {
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public double Volume { get; set; }
        [JsonIgnore]
        public double PriceAsset { get; set; }
        [JsonIgnore]
        public double Fee { get; set; }
        public char OperationType { get; set; }
        [JsonIgnore]
        public double Total { get; set; }

        public override void Validate()
        {
            AddNotifications(new AssetMovementContract(this));
        }


    }
}
