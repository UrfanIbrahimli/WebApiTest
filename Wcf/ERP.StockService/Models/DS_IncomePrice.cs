 namespace ERP.StockService
{
    using System;
    using System.Collections.Generic;

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

        public string ExternalDocNumber { get; set; }

        public DateTime? ExternalDocDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? IncomeDate { get; set; }

        public decimal? DS_StockID { get; set; }

        public decimal? RefIncomeTypeID { get; set; }

        public string Description { get; set; }

        public string Contract { get; set; }

        public DateTime? ContractDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        public DateTime? DocDueDate { get; set; }

        public decimal? PJProjectID { get; set; }

        public DateTime? OperationalDay { get; set; }

        public decimal? DsPaymentTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<DS_IncomePriceItems> DS_IncomePriceItems { get; set; }
    }
}
