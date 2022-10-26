using RestSharp;

namespace FitnessTracker.Models
{
    public class InfoBFP
    {
        public double bfp { get; set; }
        public double fat_mass { get; set; }
        public double lean_mass { get; set; }
        public string description { get; set; }
        public string gender { get; set; }

    }
}
