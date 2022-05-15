using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class TblCar
    {
        public TblCar()
        {
            TblFaculties = new HashSet<TblFaculty>();
            TblIncidents = new HashSet<TblIncident>();
            TblStudents = new HashSet<TblStudent>();
        }

        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string? Model { get; set; }
        public string? CarYear { get; set; }
        public string? Color { get; set; }
        public string? LicensePlate { get; set; }
        public float? Cost { get; set; }

        public virtual ICollection<TblFaculty> TblFaculties { get; set; }
        public virtual ICollection<TblIncident> TblIncidents { get; set; }
        public virtual ICollection<TblStudent> TblStudents { get; set; }
    }
}
