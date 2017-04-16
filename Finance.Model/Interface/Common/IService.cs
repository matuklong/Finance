using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interface.Common
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<ICollection<TEntity>> All();
        Task<ICollection<TEntity>> All(string[] includes);
        Task<ICollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, string[] includes);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void BeginTransaction();
        Task Commit();
    }
}
