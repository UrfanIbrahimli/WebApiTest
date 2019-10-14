namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DS_IncomePrice> DS_IncomePrice { get; set; }
        public virtual DbSet<DS_IncomePriceItems> DS_IncomePriceItems { get; set; }
        public virtual DbSet<DS_IncomePriseSimpleItemItems> DS_IncomePriseSimpleItemItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.ID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.StatusID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.OwnerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.BranchID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.CurrencyID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.CustomerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.PhysicalPersonID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.DS_StockID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.RefIncomeTypeID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.PJProjectID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePrice>()
                .Property(e => e.DsPaymentTypeID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.ID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.DS_IncomePriceID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.ProductUnitID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.QualityID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.VatID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.AddressID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.OwnerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.StatusID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.BranchID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.CustomerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.CurrencyID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.ContractID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriceItems>()
                .Property(e => e.WarrantyMonth)
                .HasPrecision(9, 2);

            modelBuilder.Entity<DS_IncomePriseSimpleItemItems>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DS_IncomePriseSimpleItemItems>()
                .Property(e => e.IdParent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DS_IncomePriseSimpleItemItems>()
                .Property(e => e.Ds_refBotanicTypeIDs)
                .IsUnicode(false);
        }
    }
}
