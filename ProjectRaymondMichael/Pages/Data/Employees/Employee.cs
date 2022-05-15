using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRaymondMichael
{
    public partial class Employee
    {
        public Employee()
        {
            Sales = new HashSet<Sale>();
        }
        [Display(Name = "Empirical ID")]
        public int EmpId { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name ="Date of Hire")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [Display(Name ="Home Planet")]
        public string HomePlanet { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
