using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class VProductModelCatalogDescriptionConfiguration : IEntityTypeConfiguration<VProductModelCatalogDescription>
    {
        public void Configure(EntityTypeBuilder<VProductModelCatalogDescription> builder)
        {
            builder.HasNoKey();
            builder.ToView("vProductModelCatalogDescription", "SalesLT");
            builder.HasComment("Displays the content from each element in the xml column CatalogDescription for each product in the Sales.ProductModel table that has catalog data.");
            builder.Property(e => e.Color).HasMaxLength(256);
            builder.Property(e => e.Copyright).HasMaxLength(30);
            builder.Property(e => e.Crankset).HasMaxLength(256);
            builder.Property(e => e.MaintenanceDescription).HasMaxLength(256);
            builder.Property(e => e.Material).HasMaxLength(256);
            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.NoOfYears).HasMaxLength(256);
            builder.Property(e => e.Pedal).HasMaxLength(256);
            builder.Property(e => e.PictureAngle).HasMaxLength(256);
            builder.Property(e => e.PictureSize).HasMaxLength(256);
            builder.Property(e => e.ProductLine).HasMaxLength(256);
            builder.Property(e => e.ProductModelId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductModelID");
            builder.Property(e => e.ProductPhotoId)
                .HasMaxLength(256)
                .HasColumnName("ProductPhotoID");
            builder.Property(e => e.ProductUrl)
                .HasMaxLength(256)
                .HasColumnName("ProductURL");
            builder.Property(e => e.RiderExperience).HasMaxLength(1024);
            builder.Property(e => e.Rowguid).HasColumnName("rowguid");
            builder.Property(e => e.Saddle).HasMaxLength(256);
            builder.Property(e => e.Style).HasMaxLength(256);
            builder.Property(e => e.WarrantyDescription).HasMaxLength(256);
            builder.Property(e => e.WarrantyPeriod).HasMaxLength(256);
            builder.Property(e => e.Wheel).HasMaxLength(256);
        }
    }
}
