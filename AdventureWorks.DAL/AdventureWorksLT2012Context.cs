using AdventureWorks.Core.Entities;
using AdventureWorks.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.DAL
{
    public partial class AdventureWorksLT2012Context : DbContext
    {
        public AdventureWorksLT2012Context()
        {
        }
        public AdventureWorksLT2012Context(DbContextOptions<AdventureWorksLT2012Context> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<BuildVersion> BuildVersions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<VGetAllCategory> VGetAllCategories { get; set; }
        public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }
        public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AddressCongiguration());
            modelBuilder.ApplyConfiguration(new BuildVersionConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorLogConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductModelConfiguration());
            modelBuilder.ApplyConfiguration(new ProductModelProductDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOrderHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new VGetAllCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new VProductAndDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new VProductModelCatalogDescriptionConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
