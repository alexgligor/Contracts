using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.Models;
using System;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class SellerlModel : PageModel
    {
        [BindProperty]
        public int Stage { get; set; } = 1;

        private readonly ILogger<IndexModel> _logger;

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;


        public SellerlModel(ILogger<IndexModel> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnGet()
        {

            // Extracție
            if (TempData.TryGetValue("SessionId", out object sessionId))
            {
                var sessionIdString = sessionId as string;
                // Utilizarea obiectului "person"
                var data = SessionsData.GetSesionData(sessionIdString);

                Person = data.Seller;
            }
            else
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
            }

            return Page();
            
        }

       
        public IActionResult OnPost()
        {
            var sessionId = new Random().Next(1, 100000).ToString();
            SessionsData.AddSeller(Person, sessionId);
            TempData["SessionId"] = sessionId;
            return Redirect("/Buyer");
        }
    }
}