using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.ProductId, x.MemberId });
            builder.HasOne(x => x.Product).WithMany(x => x.Baskets).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Member).WithMany(x => x.Baskets).HasForeignKey(x => x.MemberId);
        }
    }
}
