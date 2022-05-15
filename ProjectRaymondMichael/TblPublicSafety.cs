using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class TblPublicSafety
    {
        public TblPublicSafety()
        {
            TblIncidents = new HashSet<TblIncident>();
        }

        public int PsafetyId { get; set; }
        public string PGender { get; set; } = null!;
        public string Badge { get; set; } = null!;
        public string PName { get; set; } = null!;

        public virtual ICollection<TblIncident> TblIncidents { get; set; }
    }
}
