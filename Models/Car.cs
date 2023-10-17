using Contracts.Models.SQL;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ContractId { get; set; }
        private string name;
        private string model;
        private string vin;
        private string engineSN;
        private string acuisitionPaperName;
        private string plateNumber;
        private string vehicleIdentitycardnumber;

        [Required(ErrorMessage = "Câmpul Nume este obligatoriu.")]
        public string Name
        {
            get { return name; }
            set { name = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Model este obligatoriu.")]
        public string Model
        {
            get { return model; }
            set { model = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul VIN este obligatoriu.")]
        public string VIN
        {
            get { return vin; }
            set { vin = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Serie Motor este obligatoriu.")]
        public string EngineSN
        {
            get { return engineSN; }
            set { engineSN = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Ultima Inspectie Tehnica este obligatoriu.")]
        public string AcuisitionPaperName
        {
            get { return acuisitionPaperName; }
            set { acuisitionPaperName = value; }
        }

        [Required(ErrorMessage = "Câmpul Numarul Masinii este obligatoriu.")]
        public string PlateNumber
        {
            get { return plateNumber; }
            set { plateNumber = value?.ToUpper(); }
        }


        [Required(ErrorMessage = "Câmpul Numarul Cartii de Identitate este obligatoriu.")]
        public string VehicleIdentityCardNumber
        {
            get { return vehicleIdentitycardnumber; }
            set { vehicleIdentitycardnumber = value?.ToUpper(); }
        }

        [Required(ErrorMessage = "Câmpul Capacitate cilindrica este obligatoriu.")]
        public int EngineCCM { get; set; }

        [Required(ErrorMessage = "Câmpul Greutate este obligatoriu.")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Câmpul Anul Fabricatiei este obligatoriu.")]
        public int FabricationYear { get; set; }

        public int EuroPolutionNorm { get; set; }

        [Required(ErrorMessage = "Câmpul Ultima Inspectie Tehnica este obligatoriu.")]
        public DateTime LastInspection { get; set; }

        [Required(ErrorMessage = "Câmpul Data Achizitiei este obligatoriu.")]
        public DateTime AcquisitionDate { get; set; }
    }

    public interface ICarService
    {
        void Add(Car data);
    }

    public class CarService : ICarService
    {
        private readonly DataBaseContext _context;
        public CarService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void Add(Car data)
        {
            _context.Car.Add(data);
            _context.SaveChanges();
        }
    }

}
