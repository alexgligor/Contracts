using Contracts.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Contracts.Pages
{
    public class ContractModel : PageModel
    {
        public Person Seller { get; set; }  
        public Person Buyer { get; set; }
        public Car Car { get; set; }
        public FinancialInfo FinancialInfo { get; set; }


        public void OnGet()
        {
            if (TempData.TryGetValue("Seller", out object seller))
            {
                Seller = JsonConvert.DeserializeObject<Person>(seller as string);
            }

            if (TempData.TryGetValue("Buyer", out object buyer))
            {
                Seller = JsonConvert.DeserializeObject<Person>(buyer as string);
            }

            if (TempData.TryGetValue("Car", out object car))
            {
                Car = JsonConvert.DeserializeObject<Car>(car as string);
            }

            if (TempData.TryGetValue("FinancialInfo", out object finfo))
            {
                FinancialInfo = JsonConvert.DeserializeObject<FinancialInfo>(finfo as string);
            }
        }
    }
}
