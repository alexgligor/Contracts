using System.ComponentModel.DataAnnotations;

namespace Contracts.Models
{
    public class Car
    {
        [Required(ErrorMessage = "Câmpul Nume este obligatoriu.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Câmpul Model este obligatoriu.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Câmpul VIN este obligatoriu.")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Câmpul Serie Motor este obligatoriu.")]
        public string EngineSN { get; set; }

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

        public string AcuisitionPaperName { get; set; }

        [Required(ErrorMessage = "Câmpul Numarul Masinii este obligatoriu.")]
        public string PlateNumber { get; set; }
    }
}
