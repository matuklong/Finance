using Finance.Data.Interfaces;
using Finance.Model.Interface.Common;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service.Common
{
    public abstract class ServiceBase<TEntity, TContext> : IService<TEntity> where TEntity : class where TContext : IDbContext, new()
    {
        private readonly IRepository<TEntity> _repository;
        private IUnitOfWork<TContext> _uow;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async virtual Task<TEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async virtual Task<ICollection<TEntity>> All()
        {
            return await _repository.All();
        }

        public async virtual Task<ICollection<TEntity>> All(string[] includes)
        {
            return await _repository.All(includes);
        }

        public async virtual Task<ICollection<TEntity>> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Find(predicate);
        }

        public async virtual Task<ICollection<TEntity>> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, string[] includes)
        {
            return await _repository.Find(predicate, includes);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }


        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public async virtual Task Commit()
        {
            await _uow.Commit();
        }

        public void Dispose()
        {
            if (_uow != null)
            {
                _uow.Dispose();
            }
        }
    }
}
