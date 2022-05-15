using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectRaymondMichael;

namespace ProjectRaymondMichael.Pages.Data.Sales
{
    public class CreateModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;

        public CreateModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId");
        ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sales == null || Sale == null)
            {
                return Page();
            }

            _context.Sales.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
