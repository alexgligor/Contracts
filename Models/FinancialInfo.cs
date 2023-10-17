using Contracts.Models.SQL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Contracts.Models
{
    public class FinancialInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ContractId { get; set; }

        [Required(ErrorMessage = "Câmpul Pret este obligatoriu.")]
        public int Price { get; set; }

        private string location;
        public string Currency { get; set; }


        [Required(ErrorMessage = "Câmpul Locatie este obligatoriu.")]
        public string Location
        {
            get { return location; }
            set { location = value?.ToUpper(); }
        }

        public string SellerSignature { get; set; }

        public string BuyerSignature { get; set; }

        public string PriceAsString()
        {
            return getCharacters(Price.ToString());
        }
        string getCharacters(string number)
        {
            var result = "";
            if (number.Length % 3 == 2)
            {
                if (number.StartsWith('1'))
                    return result + getTextDouble(number);
            }

            return getText(number, number.Length) + " " + (number.Length > 1 ? getCharacters(number.Substring(1, number.Length - 1)) : "");
        }

        string getText(string number, int length)
        {
            var output = "";
            var character = length == 1 ? number : number.Substring(0, 1);
            if (number.Length == 1)
                output += " SI ";
            switch (character)
            {
                case "1": output += (length % 3 == 0 ? "O " : output + "UNU"); break; ;
                case "2":
                    if (length == 1) return output + "DOI";
                    else output = "DOUA"; break;
                case "3": output += "TREI"; ; break;
                case "4": output += "PATRU"; ; break;
                case "5": output += "CINCI"; ; break;
                case "6": output += "SASE"; ; break;
                case "7": output += "SAPTE"; ; break;
                case "8": output += "OPT"; ; break;
                case "9": output += "NOUA"; ; break;
                default: return "";
            }

            switch (length)
            {
                case 2: return output + "ZECI";
                case 3: return output + (character == "1" ? "SUTA" : " SUTE");
                case 4: return output + " MI";
                case 5: return output + "ZECI DE MI";
                case 6: return output + " " + (character == "1" ? "SUTA" : " SUTE") + " DE MI";
                case 7: return output + " MILIOANE";
                case 8: return output + "ZECI DE MILIOANE";
                case 9: return output + " " + (character == "1" ? "SUTA" : " SUTE") + " DE MILIOANE";
                case 10: return output + " MILIARDE";
                case 11: return output + "ZECI DE MILIARDE";
                case 12: return output + " " + (character == "1" ? "SUTA" : " SUTE") + " DE MILIARDE";
            }

            return output;
        }

        string getTextDouble(string number)
        {

            switch (number)
            {
                case "10": return "ZECE";
                case "11": return "UNSPREZECE";
                case "12": return "DOISPREZECE";
                case "13": return "TREISPREZECE";
                case "14": return "PATRUSPREZECE";
                case "15": return "CINCISPREZECE";
                case "16": return "SASESPREZECE";
                case "17": return "SAPTESPREZECE";
                case "18": return "OPTSPREZECE";
                case "19": return "NOUASPREZECE";
                default: return "";
            }
        }


    }

    public interface IFinancialInfoService
    {
        void Add(FinancialInfo data);
    }

    public class FinancialInfoService : IFinancialInfoService
    {
        private readonly DataBaseContext _context;
        public FinancialInfoService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void Add(FinancialInfo data)
        {
            _context.FinancialInfo.Add(data);
            _context.SaveChanges();
        }
    }
}
