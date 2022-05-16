using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectRaymondMichael.Pages.Analysis
{
    public class ShoppingModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;
        public ShoppingModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }
        public IList<spAffordable> spAffordable { get; set; }

        public async Task OnGetAsync()
        {
            //try
            //{
            var sqlBudget = new Microsoft.Data.SqlClient.SqlParameter("@budget", "0");
            spAffordable = await _context.spAffordables.FromSqlRaw("Exec spAffordable @budget={0}", sqlBudget).ToListAsync();

            //}
            //catch (Exception ex)
            //{
            /*  Console.WriteLine(ex);
              Console.WriteLine(spTotalSale);
          }*/
        }
        public async Task OnPostAsync()
        {
            string budget = HttpContext.Request.Form["budget"];

            var sqlBudget = new Microsoft.Data.SqlClient.SqlParameter("@budget", budget);

            spAffordable = await _context.spAffordables.FromSqlRaw("Exec spAffordable @budget", sqlBudget).ToListAsync();
        }
    }
}