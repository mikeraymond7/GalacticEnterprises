using System;
using System.Collections.Generic;

namespace ProjectRaymondMichael
{
    public partial class Item
    {
        public Item()
        {
            Sales = new HashSet<Sale>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        public string? ImageSrc { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
