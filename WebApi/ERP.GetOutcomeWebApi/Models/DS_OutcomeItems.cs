namespace ERP.GetOutcomeWebApi.Models
{
    using System;

    public partial class DS_OutcomeItems
    {
        public decimal ID { get; set; }
        public decimal? DS_OutcomeID { get; set; }

        public decimal? ProductUnitID { get; set; }

        public decimal? Quantity { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? OperationalDay { get; set; }

        public virtual DS_Outcome DS_Outcome { get; set; }
    }
}
