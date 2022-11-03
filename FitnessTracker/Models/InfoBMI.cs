namespace FitnessTracker.Models
{
    public class InfoBMI
    {
        public double bmi { get; set; }
        public string health { get; set; }
        public string healthy_bmi_range { get; set; }

        public static double ConvertHeightToCm(int inches)
        {
            double convertInches = Convert.ToDouble(inches);
            return Math.Round(convertInches * 2.54, 2);
        }

        public static double ConvertWeightToKg(int kgs)
        {
            double convertKgs = Convert.ToDouble(kgs);
            return Math.Round(convertKgs / 2.205, 2);
        }

    }
}
