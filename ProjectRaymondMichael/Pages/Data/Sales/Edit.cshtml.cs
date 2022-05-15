using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRaymondMichael;

namespace ProjectRaymondMichael.Pages.Data.Sales
{
    public class EditModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;

        public EditModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Sale Sale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale =  await _context.Sales.FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }
            Sale = sale;
           ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId");
           ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(Sale.SaleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SaleExists(int id)
        {
          return (_context.Sales?.Any(e => e.SaleId == id)).GetValueOrDefault();
        }
    }
}
