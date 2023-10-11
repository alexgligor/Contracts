namespace Contracts.Models
{
    public class FinancialInfo
    {

        public int Price { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }
        public string SellerSignature { get; set; }
        public string BuyerSignature { get; set; }
    }
}
