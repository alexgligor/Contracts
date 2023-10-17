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

        [BindProperty]
        public String SessionID{ get; set; }

        public IActionResult OnGet(string sessionid)
        {
            SessionID = sessionid;

            var data = SessionsData.GetSesionData(sessionid);

            if(data != null)
            { 
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

            // Utilizarea obiectului "person"
            SessionsData.AddBuyer(Person, SessionID);

            return RedirectToPage("/CarInfo", new { sessionid = SessionID });
        }
    }
}