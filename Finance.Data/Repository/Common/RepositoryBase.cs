using Finance.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Finance.Data.Context;
using Microsoft.Practices.ServiceLocation;
using Finance.Model.Interface.Common;

namespace Finance.Data.Repository.Common
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextFactory<FinanceContext>>().GetContextManager();
            //ServiceLocator.Current.GetInstance<IContextManager<HelpdeskContext>>();// as ContextManager<HelpdeskContext>;
            _context = contextManager.GetContext();
            _dbSet = _context.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _context; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<TEntity> Get(int id)
        {
            return await ((DbSet<TEntity>)DbSet).FindAsync(id);
        }


        public async Task<ICollection<TEntity>> All()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ICollection<TEntity>> All(string[] includes)
        {
            return await SetIncludes(null, includes).ToListAsync();
        }

        public async Task<ICollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<ICollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, string[] includes)
        {
            return await SetIncludes(predicate, includes).ToListAsync();
        }

        private IQueryable<TEntity> SetIncludes(Expression<Func<TEntity, bool>> predicate, string[] includes)
        {
            var query = predicate == null ? DbSet.AsQueryable() : DbSet.Where(predicate);

            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}
