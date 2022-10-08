using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ProductFeaturesConfuguration : IEntityTypeConfiguration<ProductFeatures>
    {
        public void Configure(EntityTypeBuilder<ProductFeatures> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.ProductId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductFeatures).HasForeignKey(x => x.ProductId);
        }
    }
}
