namespace Contracts.Models
{
    public class Car
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public string EngineSN { get; set; }
        public int EngineCCM { get; set; }
        public int Weight { get; set; }
        public int FabricationYear { get; set; }
        public int EuroPolutionNorm { get; set; }
        public DateTime LastInspection { get; set; }    
        public DateTime AcquisitionDate { get; set; }
        public string AcuisitionPaperName { get; set; }
        public string PlateNumber { get; set; }
    }
}
