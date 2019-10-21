namespace ERP.StockWindowsService.Models
{
    using System;

    public partial class DS_IncomePriseSimpleItemItems
    {
        public decimal ID { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? EnterDate { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Moisture { get; set; }

        public bool? IsFirst { get; set; }

        public decimal? IdParent { get; set; }

        public string Ds_refBotanicTypeIDs { get; set; }
        public virtual DS_IncomePriceItems DS_IncomePriceItem { get; set; }
    }
}
