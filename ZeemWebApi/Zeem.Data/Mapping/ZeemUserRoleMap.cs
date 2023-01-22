using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeem.Core.Domain;

namespace Zeem.Data.Mapping
{
    public class ZeemUserRoleMap : ZeemEntityTypeConfiguration<ZeemUserRole>
    {
        public override void Configure(EntityTypeBuilder<ZeemUserRole> builder)
        {
            builder.ToTable(nameof(ZeemUserRole));
            builder.Property(p => p.Id).HasColumnName("ZeemUserRoleId");
            builder.Ignore(p => p.Users);
            builder.Ignore(p => p.Roles);
            base.Configure(builder);
        }
    }
}
