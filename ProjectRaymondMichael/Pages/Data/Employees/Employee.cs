using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class Employee
    {
        public Employee()
        {
            Sales = new HashSet<Sale>();
        }

        public int EmpId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public string HomePlanet { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
