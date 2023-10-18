using Microsoft.EntityFrameworkCore.Diagnostics;
using System;


namespace Contracts.Models
{
    public static class SessionsData
    {
        private static System.Timers.Timer timer;
        private static Dictionary<string, CarContractData> SessionDataList = new Dictionary<string, CarContractData>();
        private static Dictionary<string, DateTime> SessionExpirations = new Dictionary<string, DateTime>();

        public static void AddSeller(Person person, string sessionId)
        {
            if (!SessionDataList.ContainsKey(sessionId))
            {
                person.isSeller = true;
                SessionDataList.Add(sessionId, new CarContractData() { Seller = person });
                SetExpiration(sessionId);
                return;
            }

            SessionDataList[sessionId].Seller = person;
        }

        public static void StartSessionDataCleanUp()
        { 
            if(timer== null)
            {
                timer = new(300000);
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
        }

        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var item in SessionExpirations)
            {
                TimeSpan timeDifference = DateTime.Now - item.Value;

                // Verifică dacă diferența este mai mare de 2 ore (120 minute).
                if (timeDifference.TotalMinutes > 120)
                {
                    if (SessionDataList.ContainsKey(item.Key))
                    {
                        SessionDataList.Remove(item.Key);
                    }

                    SessionExpirations.Remove(item.Key);
                }
            }
        }

        private static void SetExpiration( string sessionId)
        {
            if (!SessionExpirations.ContainsKey(sessionId))
            {
                SessionExpirations.Add(sessionId, DateTime.Now);
                return;
            }
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
