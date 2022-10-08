using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.ProductFeatureId, x.Id });
            builder.HasOne(x => x.ProductFeatures).WithMany(x => x.Discounts).HasForeignKey(x => x.ProductFeatureId);
        }
    }
}
