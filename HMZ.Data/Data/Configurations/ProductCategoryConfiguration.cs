using HMZ.Data.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMZ.Data.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductCategories).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(x => x.ProductCategories).HasForeignKey(x => x.CategoryId);
        }
    }
}
