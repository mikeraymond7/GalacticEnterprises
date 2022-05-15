using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectRaymondMichael
{
    public class spTotalSales
    {
        [Display(Name ="Total Credits")]
        public int TotalCredits { get; set; }
        [Display(Name ="Item Name")]
        public string Item { get; set; }  
    }
}
