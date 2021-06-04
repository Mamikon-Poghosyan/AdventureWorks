using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class VGetAllCategoryConfiguration : IEntityTypeConfiguration<VGetAllCategory>
    {
        public void Configure(EntityTypeBuilder<VGetAllCategory> builder)
        {
            builder.HasNoKey();
            builder.ToView("vGetAllCategories", "SalesLT");
            builder.Property(e => e.ParentProductCategoryName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            builder.Property(e => e.ProductCategoryName).HasMaxLength(50);
        }
    }
}
