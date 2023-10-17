using Contracts.Models.SQL;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ContractId { get; set; }
        public bool isSeller { get; set; }
        private string firstName;
        private string lastName;
        private string personalIdentificationNumber;
        private string serialCharacters;
        private string serialNumber;
        private string email;
        private string phone;
        private string address;
        private string postalCode;

        [Required(ErrorMessage = "Câmpul Prenume este obligatoriu.")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Nume este obligatoriu.")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul CNP este obligatoriu.")]
        public string PersonalIdentificationNumber
        {
            get { return personalIdentificationNumber; }
            set { personalIdentificationNumber = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Serie este obligatoriu.")]
        public string SerialCharacters
        {
            get { return serialCharacters; }
            set { serialCharacters = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Numar este obligatoriu.")]
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Email este obligatoriu.")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Câmpul Numar de Telefon este obligatoriu.")]
        public string Phone
        {
            get { return phone; }
            set { phone = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Adresa este obligatoriu.")]
        public string Address
        {
            get { return address; }
            set { address = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul GDPR este obligatoriu.")]
        public bool GDPR { get; set; }

        [Required(ErrorMessage = "Câmpul Cod Postal este obligatoriu.")]
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value?.ToUpper(); }
        }
    }

    public interface IPersonService
    {
        void Add(Person data);
    }

    public class PersonService : IPersonService
    {
        private readonly DataBaseContext _context;
        public PersonService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void Add(Person data)
        {
            _context.Person.Add(data);
            _context.SaveChanges();
        }
    }
}
