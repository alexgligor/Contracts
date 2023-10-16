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
            // Inițializați obiectul Person sau încărcați datele existente aici
            Person = new Person();
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