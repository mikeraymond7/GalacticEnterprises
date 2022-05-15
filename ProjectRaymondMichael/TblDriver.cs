using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class TblDriver
    {
        public TblDriver()
        {
            TblIncident1s = new HashSet<TblIncident1>();
        }

        public int DriverId { get; set; }
        public string Dname { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Addr { get; set; } = null!;
        public string Dstate { get; set; } = null!;
        public string Zip { get; set; } = null!;

        public virtual ICollection<TblIncident1> TblIncident1s { get; set; }
    }
}
