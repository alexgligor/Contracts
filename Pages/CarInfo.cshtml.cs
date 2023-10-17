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

        [BindProperty]
        public String SessionID { get; set; }

        public IActionResult OnGet(string sessionid)
        {
            SessionID = sessionid;

            var data = SessionsData.GetSesionData(sessionid);
            if (data == null)
            { 
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

            SessionsData.AddCarInfo(Car, SessionID);

            return RedirectToPage("/FinancialInfo", new { sessionid = SessionID });
        }
    }
}