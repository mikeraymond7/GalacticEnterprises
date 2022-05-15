using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectRaymondMichael;

namespace ProjectRaymondMichael.Pages.Data.Sales
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;

        public DetailsModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }

      public Sale Sale { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }
            else 
            {
                Sale = sale;
            }
            return Page();
        }
    }
}
