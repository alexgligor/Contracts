using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class FinancialInfoModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 4;

        [BindProperty]
        public FinancialInfo FInfo { get; set; }

        public IActionResult OnGet()
        {
            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                var data = SessionsData.GetSesionData(sessionIdString);

                FInfo = data.FinancialInfo;
            }
            else
            {
                FInfo = new FinancialInfo();
#if DEBUG
                FInfo = new FinancialInfo()
                {
                    Price = 5200,
                    Currency = "EURO",
                    Location = "Timisoara"
                };

#endif
            }

            return Page();
        }

       
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, redisplay the form with validation errors
                return Page();
            }

            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                SessionsData.AddFinancialInfo(FInfo, sessionIdString);
            }
            return Redirect("/Contract");
        }
    }
}