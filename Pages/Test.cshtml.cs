using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Contracts.Pages
{
    public class TestModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 1;

        public void OnGet()
        {
        }
    }
}
