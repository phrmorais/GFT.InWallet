using GFT.InWallet.Domain.Entity;
using System.Linq.Expressions;

namespace GFT.InWallet.Infra.Repository.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> ReadAll();
        TEntity? ReadSingle(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Delete(string symbol);
        bool Exists(string symbol);
    }
}