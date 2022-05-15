using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRaymondMichael
{
    public partial class Item
    {
        public Item()
        {
            Sales = new HashSet<Sale>();
        }
        [Display(Name = "Item ID")]
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        [Display(Name = "Image")]
        public string? ImageSrc { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
