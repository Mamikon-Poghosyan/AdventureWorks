using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("ProductModel", "SalesLT");
            builder.HasIndex(e => e.Name, "AK_ProductModel_Name")
                .IsUnique();
            builder.HasIndex(e => e.Rowguid, "AK_ProductModel_rowguid")
                .IsUnique();
            builder.HasIndex(e => e.CatalogDescription, "PXML_ProductModel_CatalogDescription");
            builder.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            builder.Property(e => e.CatalogDescription).HasColumnType("xml");
            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())");
        }
    }
}
