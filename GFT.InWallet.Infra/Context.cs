using Flunt.Notifications;
using GFT.InWallet.Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GFT.InWallet.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.Migrate();
        }
        public IDbContextTransaction? Transaction { get; private set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new AssetConfig());
            modelBuilder.ApplyConfiguration(new AssetMovementConfig());

            base.OnModelCreating(modelBuilder);
        }
        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = Database.BeginTransaction();
            return Transaction;
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Inclusion") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Inclusion").CurrentValue = DateTime.Now.Date;
                }
            };

            return base.SaveChanges();
        }
    }
}
