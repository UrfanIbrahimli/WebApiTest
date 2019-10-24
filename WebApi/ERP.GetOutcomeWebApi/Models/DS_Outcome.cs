namespace ERP.GetOutcomeWebApi.Models
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
        public DateTime? ExternalDocDate { get; set; }

        public DateTime? CreateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_OutcomeItems> DS_OutcomeItems { get; set; }
    }
}
