using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class FinancialInfoModel : PageModel
    {
        IRootService rootService;

        public FinancialInfoModel(IRootService rootService)
        {
            this.rootService= rootService;
        }

        [BindProperty]
        public int Stage { get; set; } = 4;

        [BindProperty]
        public FinancialInfo FInfo { get; set; }


        [BindProperty]
        public String SessionID { get; set; }

        public IActionResult OnGet(string sessionid)
        {
            SessionID = sessionid;

            var data = SessionsData.GetSesionData(sessionid);
            if (data == null)
            { 

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
                return Page();
            }
            SessionsData.AddFinancialInfo(FInfo, SessionID);
            rootService.Save(SessionsData.GetSesionData(SessionID));
            return RedirectToPage("/Contract", new { sessionid = SessionID });
        }
    }
}