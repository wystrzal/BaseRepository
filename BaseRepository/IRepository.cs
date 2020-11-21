using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add data to specified entity.
        /// </summary>
        void Add(TEntity entity);
        /// <summary>
        /// Delete data from specified entity.
        /// </summary>
        void Delete(TEntity entity);
        /// <summary>
        /// Update data in specified entity.
        /// </summary>
        void Update(TEntity entity);
        /// <summary>
        /// Get data to list from specified entity by condition.
        /// </summary>
        Task<List<TEntity>> GetByConditionToList(Func<TEntity, bool> condition);
        /// <summary>
        /// Get data to list from specified entity by condition, with included property.
        /// </summary>
        Task<List<TEntity>> GetByConditionWithIncludeToList<TProp>(Func<TEntity, bool> condition, Expression<Func<TEntity, TProp>> include);
        /// <summary>
        /// Get data from specified entity by condition.
        /// Throws NullDataException if not found any data.
        /// </summary>
        Task<TEntity> GetByConditionFirst(Func<TEntity, bool> condition);
        /// <summary>
        /// Get data from specified entity by condition, with included property.
        /// Throws NullDataException if not found any data.
        /// </summary>
        Task<TEntity> GetByConditionWithIncludeFirst<TProp>(Func<TEntity, bool> condition, Expression<Func<TEntity, TProp>> include);
        /// <summary>
        /// Get all data from specified entity.
        /// </summary>
        Task<List<TEntity>> GetAll();
        /// <summary>
        /// Get data from specified entity by id.
        /// Throws NullDataException if not found any data.
        /// </summary>
        Task<TEntity> GetById(int id);
        /// <summary>
        /// Save all changed to database.
        /// Throws ChangesNotSavedCorrectlyException if changes not save correctly.
        /// </summary>
        Task<bool> SaveAllAsync();
        /// <summary>
        /// Check if specified entity contains any elements from condition.
        /// </summary>
        Task<bool> CheckIfExistByCondition(Func<TEntity, bool> condition);
    }
}
