namespace ERP.WebApi.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DS_IncomePriceItems
    {
        public decimal ID { get; set; }

        public decimal? DS_IncomePriceID { get; set; }

        public decimal? ProductUnitID { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string SerialNumber { get; set; }

        public decimal? QualityID { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public decimal? VatID { get; set; }

        public decimal? VatPrice { get; set; }

        public DateTime? DocDueDate { get; set; }

        public DateTime? OperationalDay { get; set; }

        public decimal? AddressID { get; set; }

        public decimal? OwnerID { get; set; }

        public decimal? StatusID { get; set; }

        public decimal? BranchID { get; set; }

        public decimal? CustomerID { get; set; }

        public decimal? CurrencyID { get; set; }

        public decimal? ContractID { get; set; }

        public string VHFNum { get; set; }

        public DateTime? VHFDate { get; set; }

        public bool? HasWarranty { get; set; }

        public string WarrantyType { get; set; }

        public decimal? WarrantyMonth { get; set; }

        public string WarrantyDescription { get; set; }

        public string Code { get; set; }

        public DS_IncomePrice DS_IncomePrice  { get; set; }
        public DS_IncomePriseSimpleItemItems DS_IncomePriseSimpleItem { get; set; }
    }
}
