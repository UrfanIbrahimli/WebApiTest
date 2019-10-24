namespace ERP.RegionStockWindowsService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CASPELERP.DS_IncomePrice")]
    public partial class DS_IncomePrice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DS_IncomePrice()
        {
            DS_IncomePriceItems = new HashSet<DS_IncomePriceItems>();
        }

        public decimal ID { get; set; }

        public decimal StatusID { get; set; }

        public decimal? OwnerID { get; set; }

        public decimal? BranchID { get; set; }

        public decimal? CurrencyID { get; set; }

        public decimal CustomerID { get; set; }

        public decimal PhysicalPersonID { get; set; }

        [StringLength(100)]
        public string ExternalDocNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExternalDocDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? IncomeDate { get; set; }

        public decimal? DS_StockID { get; set; }

        public decimal? RefIncomeTypeID { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Contract { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ContractDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastPaymentDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DocDueDate { get; set; }

        public decimal? PJProjectID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OperationalDay { get; set; }

        public decimal? DsPaymentTypeID { get; set; }

        public bool? SendingStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_IncomePriceItems> DS_IncomePriceItems { get; set; }
    }
}
