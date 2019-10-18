namespace ERP.WebApi.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CASPELERP.DS_IncomePriseSimpleItemItems")]
    public partial class DS_IncomePriseSimpleItemItems
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(50)]
        public string SerialNumber { get; set; }

        public DateTime? EnterDate { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Moisture { get; set; }

        public bool? IsFirst { get; set; }

        public decimal? IdParent { get; set; }

        public string Ds_refBotanicTypeIDs { get; set; }
    }
}
