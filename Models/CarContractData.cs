namespace Contracts.Models
{
    public class CarContractData
    {
        public Car Car { get; set; }
        public FinancialInfo FinancialInfo { get; set; }
        public Person Seller { get; set; }
        public Person Buyer { get; set; }
    }
}
