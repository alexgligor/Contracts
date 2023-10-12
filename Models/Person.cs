using System.ComponentModel.DataAnnotations;

namespace Contracts.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Câmpul Prenume este obligatoriu.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Câmpul Nume este obligatoriu.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Câmpul CNP este obligatoriu.")]
        public string PersonalIdentificationNumber { get; set; }

        [Required(ErrorMessage = "Câmpul Serie este obligatoriu.")]
        public string SerialCharacters { get; set; }

        [Required(ErrorMessage = "Câmpul Numar este obligatoriu.")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Câmpul Email este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Câmpul Numar de Telefon este obligatoriu.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Câmpul Adresa este obligatoriu.")]
        public string Address { get; set; }
    }
}
