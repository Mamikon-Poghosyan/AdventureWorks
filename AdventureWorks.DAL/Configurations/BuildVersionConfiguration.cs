using AdventureWorks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.DAL.Configurations
{
    internal class BuildVersionConfiguration : IEntityTypeConfiguration<BuildVersion>
    {
        public void Configure(EntityTypeBuilder<BuildVersion> builder)
        {
            builder.HasNoKey();
            builder.ToTable("BuildVersion");
            builder.HasComment("Current version number of the AdventureWorksLT 2008 sample database. ");
            builder.Property(e => e.DatabaseVersion)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("Database Version")
                .HasComment("Version number of the database in 9.yy.mm.dd.00 format.");
            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            builder.Property(e => e.SystemInformationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SystemInformationID")
                .HasComment("Primary key for BuildVersion records.");
            builder.Property(e => e.VersionDate)
                .HasColumnType("datetime")
                .HasComment("Date and time the record was last updated.");
        }
    }
}
