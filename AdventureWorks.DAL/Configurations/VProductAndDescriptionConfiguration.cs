using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class VProductAndDescriptionConfiguration : IEntityTypeConfiguration<VProductAndDescription>
    {
        public void Configure(EntityTypeBuilder<VProductAndDescription> builder)
        {
            builder.HasNoKey();
            builder.ToView("vProductAndDescription", "SalesLT");
            builder.HasComment("Product names and descriptions. Product descriptions are provided in multiple languages.");
            builder.Property(e => e.Culture)
                .IsRequired()
                .HasMaxLength(6)
                .IsFixedLength(true);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(400);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.Property(e => e.ProductModel)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
