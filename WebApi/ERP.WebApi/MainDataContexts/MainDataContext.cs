using ERP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ERP.WebApi.MainDataContexts
{
    public class MainDataContext:DbContext
    {
        public MainDataContext():base("ErpDatabaseConString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DS_IncomePrice> DS_IncomePrices { get; set; }
        public DbSet<DS_IncomePriceItems> DS_IncomePriceItems { get; set; }
        public DbSet<DS_IncomePriseSimpleItemItems> DS_IncomePriseSimpleItemItems { get; set; }
        public DbSet<DS_Outcome> DS_Outcomes { get; set; }
        public DbSet<DS_OutcomeItems> DS_OutcomeItems { get; set; }
    }
}