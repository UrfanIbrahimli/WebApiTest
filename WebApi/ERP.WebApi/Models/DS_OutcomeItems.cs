namespace ERP.WebApi.Models
{
    using System;

    public partial class DS_OutcomeItems
    {
        public decimal ID { get; set; }

        public decimal? DS_OutcomeID { get; set; }

        public decimal? ProductUnitID { get; set; }

        public decimal? Quantity { get; set; }

        public string SerialNumber { get; set; }

        public decimal? QualityID { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public DateTime? DocDueDate { get; set; }

        public DateTime? OperationalDay { get; set; }

        public decimal? OwnerID { get; set; }

        public decimal? StatusID { get; set; }

        public decimal? BranchID { get; set; }

        public decimal? CustomerID { get; set; }

        public decimal? CurrencyID { get; set; }

        public decimal? ContractID { get; set; }

        public string VHFNum { get; set; }

        public DateTime? VHFDate { get; set; }

        public string Code { get; set; }

        public decimal? CurrentWeight { get; set; }

        public virtual DS_Outcome DS_Outcome { get; set; }
    }
}
