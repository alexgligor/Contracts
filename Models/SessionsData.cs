namespace Contracts.Models
{
    public static class SessionsData
    {
        private static Dictionary<string, CarContractData> SessionDataList = new Dictionary<string, CarContractData>();

        public static void AddSeller(Person person, string sessionId)
        {
            if(!SessionDataList.ContainsKey(sessionId))
            {
                SessionDataList.Add(sessionId, new CarContractData() { Seller = person });
                return;
            }

            SessionDataList[sessionId].Seller = person;           
        }

        public static void AddBuyer(Person person, string sessionId)
        {
            if (!SessionDataList.ContainsKey(sessionId))
            {
                SessionDataList.Add(sessionId, new CarContractData() { Buyer = person });
                return;
            }

            SessionDataList[sessionId].Buyer = person;
        }

        public static void AddCarInfo(Car car, string sessionId)
        {
            if (!SessionDataList.ContainsKey(sessionId))
            {
                SessionDataList.Add(sessionId, new CarContractData() { Car = car });
                return;
            }

            SessionDataList[sessionId].Car = car;
        }

        public static void AddFinancialInfo(FinancialInfo finfo, string sessionId)
        {
            if (!SessionDataList.ContainsKey(sessionId))
            {
                SessionDataList.Add(sessionId, new CarContractData() { FinancialInfo = finfo });
                return;
            }

            SessionDataList[sessionId].FinancialInfo = finfo;
        }

        public static CarContractData GetSesionData(string sessionId) 
        {
            return SessionDataList[sessionId];
        }

    }
}
