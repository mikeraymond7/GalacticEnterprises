using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectRaymondMichael.Pages.Analysis
{
    public class TotalSalesModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;
        public TotalSalesModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }
        public IList<spTotalSales> spTotalSale { get; set; }

        public async Task OnGetAsync()
        {
            //try
            //{
                spTotalSale = await _context.spTotalSales.FromSqlRaw("Exec spTotalSales").ToListAsync();

            //}
            //catch (Exception ex)
            //{
              /*  Console.WriteLine(ex);
                Console.WriteLine(spTotalSale);
            }*/
        }
        public async Task OnPostAsync()
        {
            spTotalSale = await _context.spTotalSales.FromSqlRaw("Exec spTotalSales").ToListAsync();
        }
    }
}
