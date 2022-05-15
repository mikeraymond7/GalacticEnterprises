using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRaymondMichael
{
    public partial class VwPurchase
    {
        [Display(Name = "Empirical Name")]
        public string EmpiricalName { get; set; } = null!;
        public string Item { get; set; } = null!;
        public int Credits { get; set; }
        [Display(Name = "Date of Purchase")]
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
    }
}
