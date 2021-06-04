using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.HasKey(e => e.SalesOrderId)
                    .HasName("PK_SalesOrderHeader_SalesOrderID");
            builder.ToTable("SalesOrderHeader", "SalesLT");
            builder.HasComment("General sales order information.");
            builder.HasIndex(e => e.SalesOrderNumber, "AK_SalesOrderHeader_SalesOrderNumber")
                .IsUnique();
            builder.HasIndex(e => e.Rowguid, "AK_SalesOrderHeader_rowguid")
                .IsUnique();
            builder.HasIndex(e => e.CustomerId, "IX_SalesOrderHeader_CustomerID");
            builder.Property(e => e.SalesOrderId)
                .HasColumnName("SalesOrderID")
                .HasComment("Primary key.");
            builder.Property(e => e.AccountNumber)
                .HasMaxLength(15)
                .HasComment("Financial accounting number reference.");
            builder.Property(e => e.BillToAddressId)
                .HasColumnName("BillToAddressID")
                .HasComment("The ID of the location to send invoices.  Foreign key to the Address table.");
            builder.Property(e => e.Comment).HasComment("Sales representative comments.");
            builder.Property(e => e.CreditCardApprovalCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Approval code provided by the credit card company.");
            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasComment("Customer identification number. Foreign key to Customer.CustomerID.");
            builder.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasComment("Date the order is due to the customer.");
            builder.Property(e => e.Freight)
                .HasColumnType("money")
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping cost.");
            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            builder.Property(e => e.OnlineOrderFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.");
            builder.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Dates the sales order was created.");
            builder.Property(e => e.PurchaseOrderNumber)
                .HasMaxLength(25)
                .HasComment("Customer purchase order number reference. ");
            builder.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the sales order over time.");
            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            builder.Property(e => e.SalesOrderNumber)
                .IsRequired()
                .HasMaxLength(25)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***'))", false)
                .HasComment("Unique sales order identification number.");
            builder.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasComment("Date the order was shipped to the customer.");
            builder.Property(e => e.ShipMethod)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");
            builder.Property(e => e.ShipToAddressId)
                .HasColumnName("ShipToAddressID")
                .HasComment("The ID of the location to send goods.  Foreign key to the Address table.");
            builder.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");
            builder.Property(e => e.SubTotal)
                .HasColumnType("money")
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.");
            builder.Property(e => e.TaxAmt)
                .HasColumnType("money")
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax amount.");
            builder.Property(e => e.TotalDue)
                .HasColumnType("money")
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.");
            builder.HasOne(d => d.BillToAddress)
                .WithMany(p => p.SalesOrderHeaderBillToAddresses)
                .HasForeignKey(d => d.BillToAddressId)
                .HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");
            builder.HasOne(d => d.Customer)
                .WithMany(p => p.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.ShipToAddress)
                .WithMany(p => p.SalesOrderHeaderShipToAddresses)
                .HasForeignKey(d => d.ShipToAddressId)
                .HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
        }
    }
}
