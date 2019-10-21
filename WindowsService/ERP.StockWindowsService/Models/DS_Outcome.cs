namespace ERP.StockWindowsService.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DS_Outcome
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DS_Outcome()
        {
            DS_OutcomeItems = new HashSet<DS_OutcomeItems>();
        }

        public decimal ID { get; set; }

        public decimal StatusID { get; set; }

        public decimal? OwnerID { get; set; }

        public decimal? BranchID { get; set; }

        public decimal? CustomerID { get; set; }

        public decimal PhysicalPersonID { get; set; }

        public string ExternalDocNumber { get; set; }

        public DateTime? ExternalDocDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? OutcomeDate { get; set; }

        public decimal? DS_StockID { get; set; }

        public decimal? RefOutcomeTypeID { get; set; }

        public string Description { get; set; }

        public decimal? CurrencyID { get; set; }

        public DateTime? DocDueDate { get; set; }

        public decimal? PJProjectID { get; set; }

        public DateTime? OperationalDay { get; set; }

        public decimal? RefAddressID { get; set; }

        public decimal? StructID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_OutcomeItems> DS_OutcomeItems { get; set; }
    }
}
