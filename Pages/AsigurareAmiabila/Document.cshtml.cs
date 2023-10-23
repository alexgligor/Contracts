using Contracts.Models.AsigurareAmiabila;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Contracts.Pages.AsigurareAmiabila
{
    public class DocumentModel : PageModel
    {
        public PersonAsigurare PersonA{ get; set; }   
        
        public PersonAsigurare PersonB{ get; set; }

        public void OnGet()
        {
#if DEBUG
            PersonA = new PersonAsigurare() 
            { 
                Name="Popescu", 
                FirstName="Andrei",
                Country="Romania",
                Address ="Timis, Str.Demetriade, Nr.34A, SC.3, Ap.34, Et.5",
                PostalCode = "346234",
                Phone="0785654256",
                Email="popescu.andrei@gmail.com"
            };
            PersonB = new PersonAsigurare()
            {
                Name = "Barbu",
                FirstName = "Florian",
                Country = "Romania",
                Address = "Timis, Str.Popa Sapca, Nr.3A, SC.1, Ap.4, Et.1",
                PostalCode = "445332",
                Phone = "0785679256",
                Email = "barbu.florian@gmail.com"
            };
#endif
        }
    }
}
