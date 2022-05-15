using System.ComponentModel.DataAnnotations;

namespace ProjectRaymondMichael
{
    public class spAffordable
    {
        [Display(Name = "Item Name")]
        public string Item { get; set; }
        [Display(Name = "Credits")]
        public int Credits { get; set; }
        
    }
}
