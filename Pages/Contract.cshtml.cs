using Contracts.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class ContractModel : PageModel
    {
        public Person Person { get; set; }  

        public void OnGet()
        {
            // Extracție
            if (TempData.TryGetValue("Seller", out object personData))
            {
                Person = JsonConvert.DeserializeObject<Person>(personData as string);
                // Utilizarea obiectului "person"
            }
        }
    }
}
