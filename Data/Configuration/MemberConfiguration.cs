using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.RoleId });
            builder.HasOne(x => x.Role).WithMany(x => x.Member).HasForeignKey(x => x.RoleId);
        }
    }
}
