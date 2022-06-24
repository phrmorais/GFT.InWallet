using GFT.InWallet.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Infra.Config
{
    public class AssetMovementConfig : IEntityTypeConfiguration<AssetMovement>
    {
        public void Configure(EntityTypeBuilder<AssetMovement> builder)
        {
            //builder.HasKey(c => c.Id);
        }
    }
}
