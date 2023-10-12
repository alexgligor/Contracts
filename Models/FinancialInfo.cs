using System.ComponentModel.DataAnnotations;

namespace Contracts.Models
{
    public class FinancialInfo
    {
        [Required(ErrorMessage = "Câmpul Pret este obligatoriu.")]
        public int Price { get; set; }

        public string Currency { get; set; }

        [Required(ErrorMessage = "Câmpul Locatie este obligatoriu.")]
        public string Location { get; set; }

        public string SellerSignature { get; set; }

        public string BuyerSignature { get; set; }
    }
}
