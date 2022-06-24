using GFT.InWallet.Domain.Entity;
using GFT.InWallet.Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Context Context;

        public BaseRepository(Context context)
        {
            Context = context;
        }

        public void Create(TEntity entity)
        {
            Context.InitTransacao();
            Context.Set<TEntity>().Add(entity).State = EntityState.Added;
            Context.SendChanges();
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity? ReadSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Update(TEntity entity)
        {
            Context.InitTransacao();
            Context.Set<TEntity>().Update(entity).State = EntityState.Modified;
            Context.SendChanges();
        }

        public void Delete(string symbol)
        {
            var entidade = ReadSingle(u => u.Symbol == symbol);
            if (entidade != null)
            {
                Context.InitTransacao();
                Context.Set<TEntity>().Remove(entidade).State = EntityState.Deleted;
                Context.SendChanges();
            }
        }
        public bool Exists(string symbol)
        {
            return ReadSingle(u => u.Symbol == symbol) is not null;
        }
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
        public void Dispose()
        {
            Context.Dispose();
        }



        public ICollection<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }
    }
}
