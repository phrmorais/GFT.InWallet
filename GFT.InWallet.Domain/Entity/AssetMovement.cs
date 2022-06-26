using GFT.InWallet.Domain.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Entity
{
    public class AssetMovement : BaseEntity
    {
        public decimal Volume { get; set; }
        public decimal PriceAsset { get; set; }
        public decimal Fee { get; set; }
        public char Operation { get; set; }
        public decimal Total { get; set; }

        public override void IsValidate()
        {
            throw new NotImplementedException();
        }
    }
}
