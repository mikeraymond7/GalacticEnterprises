using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRaymondMichael
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        
        public int EmpId { get; set; }
        
        public int ItemId { get; set; }
        [Display(Name = "Date of Purchase")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Empirical ID")]
        public virtual Employee Emp { get; set; } = null!;
        [Display(Name = "Item ID")]
        public virtual Item Item { get; set; } = null!;
    }
}
