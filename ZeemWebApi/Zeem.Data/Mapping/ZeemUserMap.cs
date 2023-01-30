using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeem.Core.Domain;

namespace Zeem.Data.Mapping
{
    public class ZeemUserMap : ZeemEntityTypeConfiguration<ZeemUser>
    {
        public override void Configure(EntityTypeBuilder<ZeemUser> builder)
        {
            builder.ToTable(nameof(ZeemUser));
            builder.Property(p => p.Id).HasColumnName("ZeemUserId");
            builder.Ignore(p => p.UserRole);
            base.Configure(builder);
        }
    }
}
