using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class CarInfoModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 3;

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet()
        {
            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                var data = SessionsData.GetSesionData(sessionIdString);

                Car = data.Car;
            }
            else
            {
                Car = new Car();

            }
#if DEBUG
            Car = new Car()
            {
                Name = "BMW",
                Model = "X5",
                VIN = "BM345DF556743547543",
                PlateNumber = "TM11BNF",
                EngineSN = "RT456G",
                EngineCCM = 2245,
                EuroPolutionNorm = 5,
                AcquisitionDate = DateTime.Now,
                AcuisitionPaperName = "",
                FabricationYear = 2019,
                LastInspection = DateTime.Now,
                Weight = 2000
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
                SessionsData.AddCarInfo(Car, sessionIdString);
            }

            return Redirect("/FinancialInfo");
        }
    }
}