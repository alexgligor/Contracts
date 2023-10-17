using Contracts.Models.SQL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    public class Contract {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }

    public class CarContractData
    { 
        public Car Car { get; set; }
        public FinancialInfo FinancialInfo { get; set; }
        public Person Seller { get; set; }
        public Person Buyer { get; set; }
    }

    public interface IContractService
    {
        Contract Add();
    }

    public class ContractService: IContractService
    {
        private readonly DataBaseContext _context;
        public ContractService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Contract Add()
        {
            var data = new Contract() { Created = DateTime.Now };
            _context.Contract.Add(data);
            _context.SaveChanges();
                return data;
        }
    }
}
