using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;

namespace Contracts.Pages
{
    public class BuyerModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 2;

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnGet()
        {
            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                var data = SessionsData.GetSesionData(sessionIdString);

                Person = data.Buyer;
            }
            else
            {
                Person = new Person();

            }
#if DEBUG
            Person = new Person()
            {
                FirstName = "Deian",
                LastName = "Vigaru",
                Email = "vigarudeaian@gmail.com",
                Address = "Jud.Timis, Loc.Ghiroda, Str.Vulturilor, Nr.14 A",
                Phone = "0745896532",
                PersonalIdentificationNumber = "1983234543745",
                SerialCharacters = "TZ",
                SerialNumber = "458695"
            };

#endif

            return Page();
        }

       
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, redisplay the form with validation errors
                return Page();
            }

            
            // Extracție
            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                SessionsData.AddBuyer(Person, sessionIdString);
            }

            return Redirect("/CarInfo");
        }
    }
}