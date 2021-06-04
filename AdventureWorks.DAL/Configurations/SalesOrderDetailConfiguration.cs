using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
        {
            builder.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId })
                    .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");
            builder.ToTable("SalesOrderDetail", "SalesLT");
            builder.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");
            builder.HasIndex(e => e.Rowguid, "AK_SalesOrderDetail_rowguid")
                .IsUnique();
            builder.HasIndex(e => e.ProductId, "IX_SalesOrderDetail_ProductID");
            builder.Property(e => e.SalesOrderId)
                .HasColumnName("SalesOrderID")
                .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");
            builder.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SalesOrderDetailID")
                .HasComment("Primary key. One incremental unique number per product sold.");
            builder.Property(e => e.LineTotal)
                .HasColumnType("numeric(38, 6)")
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.");
            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            builder.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");
            builder.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .HasComment("Product sold to customer. Foreign key to Product.ProductID.");
            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            builder.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasComment("Selling price of a single product.");
            builder.Property(e => e.UnitPriceDiscount)
                .HasColumnType("money")
                .HasComment("Discount amount.");
            builder.HasOne(d => d.Product)
                .WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.SalesOrder)
                .WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.SalesOrderId);
        }
    }
}
