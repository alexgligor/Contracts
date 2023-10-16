using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;

namespace Contracts.Pages
{
    public class SellerlModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 1;

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnGet()
        {

            
                Person = new Person();
#if DEBUG
                Person = new Person()
                {
                    FirstName = "Alex",
                    LastName = "Gligor",
                    Email = "alexgligor@gmail.com",
                    Address = "Jud.Timis, Loc.Giarmata, Str.Primaverii, Nr.90",
                    Phone = "0744138843",
                    PersonalIdentificationNumber = "1910302012345",
                    SerialCharacters = "TZ",
                    SerialNumber = "905656"
                };
#endif

            return Page();
            
        }

       
        public IActionResult OnPost()
        {
            var sessionId = new Random().Next(1, 100000).ToString();
            SessionsData.AddSeller(Person, sessionId);

            return RedirectToPage("/Buyer", new { sessionid = sessionId });
        }
    }
}