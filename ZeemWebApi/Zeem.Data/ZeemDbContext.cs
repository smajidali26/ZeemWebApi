using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zeem.Core;
using Zeem.Data.Mapping;

namespace Zeem.Data
{
    public class ZeemDbContext : DbContext, IDbContext
    {
        #region Members


        #endregion

        #region Ctor

        #endregion
        
        #region Methods
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(ZeemEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

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

        #endregion
    }
}
