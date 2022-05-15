using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class TblIncident
    {
        public int IncidentId { get; set; }
        public DateTime IncidentDate { get; set; }
        public int? StudentId { get; set; }
        public int? Facultyid { get; set; }
        public int PsafetyId { get; set; }
        public int? Carid { get; set; }
        public string? Comments { get; set; }

        public virtual TblCar? Car { get; set; }
        public virtual TblFaculty? Faculty { get; set; }
        public virtual TblPublicSafety Psafety { get; set; } = null!;
        public virtual TblStudent? Student { get; set; }
    }
}
