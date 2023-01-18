using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using Zeem.Core;
using Zeem.Data.Mapping;

namespace Zeem.Data
{
    public class ZeemDbContext : DbContext, IDbContext
    {
        #region Members


        #endregion

        #region Ctor
        public ZeemDbContext(DbContextOptions<ZeemDbContext> dbContextOptions)
           : base(dbContextOptions)
        {
                        
        }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(ZeemEntityTypeConfiguration<>));
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZeemDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        
        public void Detach(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.Detach(entity);
        }

        DbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        #endregion
    }
}