using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectRaymondMichael;

namespace ProjectRaymondMichael.Pages.Data.Items
{
    public class ItemsModel : PageModel
    {
        private readonly ProjectRaymondMichael.MRaymond2Context _context;

        public ItemsModel(ProjectRaymondMichael.MRaymond2Context context)
        {
            _context = context;
        }

        public IList<Item> Item { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Items != null)
            {
                Item = await _context.Items.ToListAsync();
            }
        }
    }
}
