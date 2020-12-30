using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Dtl.Repositories.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task <IEnumerable<TEntity>> GetAllEntities();
        Task <TEntity> GetEntity(Guid id);
        IEnumerable<TEntity>FindEntity (Expression<Func<TEntity,bool>> predicate);
        Task AddEntity(TEntity entity);
        Task AddEntities(List<TEntity> entities);
        void DeleteEntity(TEntity entity);
        void DeleteEntities(List<TEntity> entities);
    }
}
