using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.ToTable("ErrorLog");
            builder.HasComment("Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.");
            builder.Property(e => e.ErrorLogId)
                .HasColumnName("ErrorLogID")
                .HasComment("Primary key for ErrorLog records.");
            builder.Property(e => e.ErrorLine).HasComment("The line number at which the error occurred.");
            builder.Property(e => e.ErrorMessage)
                .IsRequired()
                .HasMaxLength(4000)
                .HasComment("The message text of the error that occurred.");
            builder.Property(e => e.ErrorNumber).HasComment("The error number of the error that occurred.");
            builder.Property(e => e.ErrorProcedure)
                .HasMaxLength(126)
                .HasComment("The name of the stored procedure or trigger where the error occurred.");
            builder.Property(e => e.ErrorSeverity).HasComment("The severity of the error that occurred.");
            builder.Property(e => e.ErrorState).HasComment("The state number of the error that occurred.");
            builder.Property(e => e.ErrorTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("The date and time at which the error occurred.");
            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(128)
                .HasComment("The user who executed the batch in which the error occurred.");
        }
    }
}
