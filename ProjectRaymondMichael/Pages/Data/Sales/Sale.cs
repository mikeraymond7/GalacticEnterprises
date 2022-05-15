using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int EmpId { get; set; }
        public int ItemId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Employee Emp { get; set; } = null!;
        public virtual Item Item { get; set; } = null!;
    }
}
