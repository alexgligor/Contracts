using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class ContractModel : PageModel
    {
        public CarContractData CarContractData { get; set; }

        [BindProperty]
        public int Stage { get; set; } = 5;

        public void OnGet()
        {
            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                CarContractData = SessionsData.GetSesionData(sessionIdString);
                
            }
        }
    }
}
