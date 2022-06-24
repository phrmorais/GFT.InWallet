using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Entity
{
    public class Asset : BaseEntity
    {
        public string? Company { get; set; }
        //public List<AssetMovement> AssetMovements { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
