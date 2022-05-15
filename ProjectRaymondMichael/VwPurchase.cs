using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class VwPurchase
    {
        public string EmpiricalName { get; set; } = null!;
        public string Item { get; set; } = null!;
        public int Credits { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
