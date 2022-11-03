using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Root
    {
        [Required(ErrorMessage = "This is required")]
        [Range(0, 100, ErrorMessage = "This should be in the range between 0 and 100")]
        public int height { get; set; }

        [Required]
        [Range(0, 1000)]
        public int weight { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string gender { get; set; }

        //[Required]
        //public int Kgs { get; set; }


    }
}
