

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;
using Zeem.Core;

namespace Zeem.Data.Mapping
{
    public class ZeemEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {        

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            PostInitialize(builder);
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected void PostInitialize(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.CreatedBy);
            builder.Property(m => m.ModifiedDate);
            builder.Property(m => m.ModifiedBy);
            builder.Property(m => m.DeletedDate);
            builder.Property(m => m.DeletedBy);
            builder.Property(m => m.IsDeleted);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
