using Microsoft.EntityFrameworkCore;
using PromtTranslation.Dtl.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Dtl.Repositories.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public BaseRepository (DbContext context )
        {
            _context = context;
        }
        public async Task AddEntities(List<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task AddEntity(TEntity entity)
        {
            await _context.Set<TEntity>().AddRangeAsync(entity);
        }

        public void DeleteEntities(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void DeleteEntity(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> FindEntity(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllEntities()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetEntity(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
