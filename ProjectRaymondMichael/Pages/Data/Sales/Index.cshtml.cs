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
    public class IndexModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;

        public IndexModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }

        public IList<Sale> Sale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sales != null)
            {
                Sale = await _context.Sales
                .Include(s => s.Emp)
                .Include(s => s.Item).ToListAsync();
            }
        }
    }
}
