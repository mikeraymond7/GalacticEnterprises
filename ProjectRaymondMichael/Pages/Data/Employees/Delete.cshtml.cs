using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectRaymondMichael;

namespace ProjectRaymondMichael.Pages.Data.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;

        public DeleteModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmpId == id);

            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                Employee = employee;
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
