using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Root
    {
        public double height { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
}
