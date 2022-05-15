using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class TblViolation
    {
        public TblViolation()
        {
            TblIncident1s = new HashSet<TblIncident1>();
        }

        public int ViolationId { get; set; }
        public string? Violation { get; set; }
        public int? Fine { get; set; }

        public virtual ICollection<TblIncident1> TblIncident1s { get; set; }
    }
}
