namespace ERP.OutcomeWebApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CASPELERP.DS_IncomePriceItems")]
    public partial class DS_IncomePriceItems
    {
        public decimal ID { get; set; }

        public decimal? DS_IncomePriceID { get; set; }

        public decimal? ProductUnitID { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Price { get; set; }

        [StringLength(150)]
        public string SerialNumber { get; set; }

        public decimal? QualityID { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public decimal? VatID { get; set; }

        public decimal? VatPrice { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DocDueDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OperationalDay { get; set; }

        public decimal? AddressID { get; set; }

        public decimal? OwnerID { get; set; }

        public decimal? StatusID { get; set; }

        public decimal? BranchID { get; set; }

        public decimal? CustomerID { get; set; }

        public decimal? CurrencyID { get; set; }

        public decimal? ContractID { get; set; }

        public string VHFNum { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? VHFDate { get; set; }

        public bool? HasWarranty { get; set; }

        [StringLength(50)]
        public string WarrantyType { get; set; }

        public decimal? WarrantyMonth { get; set; }

        [Column(TypeName = "ntext")]
        public string WarrantyDescription { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public virtual DS_IncomePrice DS_IncomePrice { get; set; }
    }
}
