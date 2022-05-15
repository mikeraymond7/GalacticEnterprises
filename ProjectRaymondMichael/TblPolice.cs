using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class TblPolice
    {
        public TblPolice()
        {
            TblIncident1s = new HashSet<TblIncident1>();
        }

        public int PoliceId { get; set; }
        public string Pname { get; set; } = null!;

        public virtual ICollection<TblIncident1> TblIncident1s { get; set; }
    }
}
