using Contracts.Models.SQL;

namespace Contracts.Models
{
    public class CarContractData
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }   
        public Car Car { get; set; }
        public FinancialInfo FinancialInfo { get; set; }
        public Person Seller { get; set; }
        public Person Buyer { get; set; }
    }

    public interface ICarContractDataService
    {
        CarContractData Add(CarContractData data);
    }

    public class CarContractDataService: ICarContractDataService
    {
        private readonly DataBaseContext _context;
        public CarContractDataService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public CarContractData Add(CarContractData data)
        {
            data.Created= DateTime.Now;
            _context.Contract.Add(data);
            _context.SaveChanges();
        return data;
        }
    }
}
