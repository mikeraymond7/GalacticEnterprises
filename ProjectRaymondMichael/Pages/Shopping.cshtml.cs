using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectRaymondMichael.Pages
{
    public class ShoppingModel : PageModel
    {
        private readonly ILogger<ShoppingModel> _logger;

        public ShoppingModel(ILogger<ShoppingModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}