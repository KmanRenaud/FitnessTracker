using FitnessTracker.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FitnessTracker.FItnessAPI
{
    public class ClientConn
    {
        public InfoBMI HTTPBMIConn(int weight, int height)
        {
            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bmi?weight={weight}&height={height}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "cc450cdb9amsh0b1d69419475dd9p1b578ejsnc1c449292f91");
            request.AddHeader("X-RapidAPI-Host", "mega-fitness-calculator1.p.rapidapi.com");
            var response = client.Execute(request).Content;
            
            InfoBMI infoBMI = new InfoBMI();

            var formattedResponse = JObject.Parse(response)["info"];

            infoBMI.bmi = (double)formattedResponse["bmi"];

            infoBMI.health = (string)formattedResponse["health"];

            infoBMI.healthy_bmi_range = (string)formattedResponse["healthy_bmi_range"];



            return infoBMI;
        }
    }
}
