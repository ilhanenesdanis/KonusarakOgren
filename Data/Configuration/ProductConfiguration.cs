using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.BrandId, x.Id ,x.BarcodeNo});
            builder.Property(x => x.BarcodeNo).HasMaxLength(15).IsRequired();
            builder.HasOne(x => x.Brand).WithMany(x => x.Product).HasForeignKey(x => x.BrandId);
        }
    }
}
