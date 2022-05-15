using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectRaymondMichael.Pages.DataVisualization.Views
{
    public class PurchasesModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;
        public PurchasesModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }
        public IList<VwPurchase> VwPurchase { get; set; }
        public async Task OnGetAsync()
        {
            VwPurchase = await _context.VwPurchases.ToListAsync();
        }

    }
}
