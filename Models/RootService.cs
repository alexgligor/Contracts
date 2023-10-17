namespace Contracts.Models
{
    public interface IRootService
    {
        void Save(CarContractData data);
    }
    public class RootService : IRootService
    {
        ICarService carService;
        IPersonService personService;
        ICarContractDataService contractService;
        IFinancialInfoService financialService;

        public RootService(ICarService carService,
        IPersonService personService,
        ICarContractDataService contractService,
        IFinancialInfoService financialService)
        {
            this.carService = carService;
            this.personService = personService;
            this.contractService = contractService;
            this.financialService= financialService;
        }

        public void Save(CarContractData data)
        {
            var contract = contractService.Add(data);
            data.Car.ContractId = contract.Id;
            data.Seller.ContractId= contract.Id;
            data.Buyer.ContractId= contract.Id;
            data.FinancialInfo.ContractId= contract.Id;
            carService.Add(data.Car);
            personService.Add(data.Seller);
            personService.Add(data.Buyer);
            financialService.Add(data.FinancialInfo);
        }
    }
}
