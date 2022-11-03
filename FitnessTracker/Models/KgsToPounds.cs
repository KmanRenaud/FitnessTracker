using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class KgsToPounds
    {

        [Required]
        public double KgsAreLbs { get; set; }

    }
}
