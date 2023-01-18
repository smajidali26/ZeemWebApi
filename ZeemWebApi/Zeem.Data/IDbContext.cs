using Microsoft.EntityFrameworkCore;
using Zeem.Core;

namespace Zeem.Data
{
    public interface IDbContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
                
        /// <summary>
        /// Detach an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Detach(object entity);

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns>Result</returns>
        Task<int> SaveChangesAsync();


    }
}