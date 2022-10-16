using HMZ.Data.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMZ.Data.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250).IsUnicode();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired();
            builder.HasMany(x => x.ProductCategories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
