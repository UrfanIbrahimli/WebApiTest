namespace ERP.WebApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ERP.WebApi.Entity;

    public partial class MainDataContext : DbContext
    {
        public MainDataContext()
            : base("name=ErpStockConString")
        {
        }

        public virtual DbSet<DS_IncomePrice> DS_IncomePrice { get; set; }
        public virtual DbSet<DS_IncomePriceItems> DS_IncomePriceItems { get; set; }
        public virtual DbSet<DS_Outcome> DS_Outcome { get; set; }
        public virtual DbSet<DS_OutcomeItems> DS_OutcomeItems { get; set; }
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

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.ID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.StatusID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.OwnerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.BranchID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.CustomerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.PhysicalPersonID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.DS_StockID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.RefOutcomeTypeID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.CurrencyID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.PJProjectID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.RefAddressID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_Outcome>()
                .Property(e => e.StructID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.ID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.DS_OutcomeID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.ProductUnitID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.QualityID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.OwnerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.StatusID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.BranchID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.CustomerID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.CurrencyID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_OutcomeItems>()
                .Property(e => e.ContractID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DS_IncomePriseSimpleItemItems>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DS_IncomePriseSimpleItemItems>()
                .Property(e => e.IdParent)
                .HasPrecision(18, 0);
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.CreateDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.ContractDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.DocDueDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.ExternalDocDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.IncomeDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.LastPaymentDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePrice>().Property(d => d.OperationalDay).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePriceItems>().Property(d => d.DocDueDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_IncomePriseSimpleItemItems>().Property(d => d.EnterDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_Outcome>().Property(d => d.CreateDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_Outcome>().Property(d => d.DocDueDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_Outcome>().Property(d => d.ExternalDocDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_Outcome>().Property(d => d.OutcomeDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_Outcome>().Property(d => d.OperationalDay).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_OutcomeItems>().Property(d => d.DocDueDate).HasColumnType("datetime2");
            //modelBuilder.Entity<DS_OutcomeItems>().Property(d => d.OperationalDay).HasColumnType("datetime2");

            modelBuilder.Entity<DS_IncomePriseSimpleItemItems>()
                .Property(e => e.Ds_refBotanicTypeIDs)
                .IsUnicode(false);
        }
    }
}
