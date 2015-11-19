namespace JagStore
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JagStoreContext : DbContext
    {
        public JagStoreContext()
            : base("name=JagStoreContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDiscription> ProductDiscriptions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.StateCode)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .Property(e => e.Zip)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Invoice>()
                .Property(e => e.ShippingState)
                .IsFixedLength();

            modelBuilder.Entity<Invoice>()
                .Property(e => e.ShippingZip)
                .IsFixedLength();

            modelBuilder.Entity<Invoice>()
                .Property(e => e.ShippingCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Tax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalDue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceItems)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.SalePrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.InvoiceItems)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductDiscription>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<ProductDiscription>()
                .Property(e => e.RetailPrice)
                .HasPrecision(10, 4);
        }
    }
}
