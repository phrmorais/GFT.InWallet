using GFT.InWallet.Repository.Config;
using Microsoft.EntityFrameworkCore;

namespace GFT.InWallet.Repository
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new AssetConfig());
            //modelBuilder.ApplyConfiguration(new AssetMovementConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
