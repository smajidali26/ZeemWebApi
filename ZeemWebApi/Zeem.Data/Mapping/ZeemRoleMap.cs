using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeem.Core.Domain;

namespace Zeem.Data.Mapping
{
    public class ZeemRoleMap : ZeemEntityTypeConfiguration<ZeemRole>
    {
        public override void Configure(EntityTypeBuilder<ZeemRole> builder)
        {
            builder.ToTable(nameof(ZeemRole));
            builder.Property(p => p.Id).HasColumnName("ZeemRoleId");
            builder.Ignore(p => p.UserRole);
            base.Configure(builder);
        }
    }
}
