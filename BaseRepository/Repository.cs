using BaseRepository.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseRepository
{
    public class Repository<TEntity, TDataContext> : IRepository<TEntity>
        where TEntity : class
        where TDataContext : DbContext
    {
        private readonly TDataContext dataContext;

        public Repository(TDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            dataContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dataContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dataContext.Set<TEntity>().Update(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetByConditionToList(Expression<Func<TEntity, bool>> condition)
        {
            return await dataContext.Set<TEntity>().Where(condition).ToListAsync();
        }

        public async Task<TEntity> GetByConditionFirst(Expression<Func<TEntity, bool>> condition)
        {
            return await dataContext.Set<TEntity>().Where(condition).FirstOrDefaultAsync() ?? throw new NullDataException();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dataContext.Set<TEntity>().FindAsync(id) ?? throw new NullDataException();
        }

        public async Task<TEntity> GetByConditionWithIncludeFirst<TProp>(Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, TProp>> include)
        {
            return await dataContext.Set<TEntity>().Include(include).Where(condition).FirstOrDefaultAsync() ?? throw new NullDataException();
        }

        public async Task<List<TEntity>> GetByConditionWithIncludeToList<TProp>(Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, TProp>> include)
        {
            return await dataContext.Set<TEntity>().Include(include).Where(condition).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await dataContext.SaveChangesAsync() > 0 ? true : throw new ChangesNotSavedCorrectlyException(typeof(TEntity));
        }

        public async Task<bool> CheckIfExistByCondition(Expression<Func<TEntity, bool>> condition)
        {
            return await dataContext.Set<TEntity>().Where(condition).AnyAsync();
        }
    }
}