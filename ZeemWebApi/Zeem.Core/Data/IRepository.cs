using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zeem.Core.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Get Object by predicate expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get Objects by predicate expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ICollection<T>> GetList(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        Task Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>-
        Task Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        Task Update(IEnumerable<T> entities);

        /// <summary>
        /// Soft Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task SoftDelete(T entity);

        /// <summary>
        /// Soft delete list of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task SoftDelete(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        Task Delete(IEnumerable<T> entities);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        Task<ICollection<TEntity>> ExecuteStoredProcedureList<TEntity>(string commandText, object[] parameters) where TEntity : BaseEntity, new();

        Task<TEntity> ExecuteStoredProcedure<TEntity>(string commandText, object[] parameters);
    }
}
