using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class BuyerModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 2;

        private readonly ILogger<IndexModel> _logger;

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;


        public BuyerModel(ILogger<IndexModel> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnGet()
        {
            // Inițializați obiectul Person sau încărcați datele existente aici
            Person = new Person();
            return Page();
        }

       
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, redisplay the form with validation errors
                return Page();
            }

            TempData["Buyer"] = JsonConvert.SerializeObject(Person);

            
            // Extracție
            if (TempData.TryGetValue("Seller", out object personData))
            {
                var person = JsonConvert.DeserializeObject<Person>(personData as string);
                // Utilizarea obiectului "person"
            }

            return Redirect("/CarInfo");
        }
    }
}