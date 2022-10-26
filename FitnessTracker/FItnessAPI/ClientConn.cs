using FitnessTracker.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FitnessTracker.FItnessAPI
{
    public class ClientConn
    {

        //public InfoBMR HTTPBMRConn(int weight, int height, int age, string gender)
        //{
        //    var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bmr?weight={weight}&height={height}&age={age}&gender={gender}");
        //    var request = new RestRequest();
        //    request.AddHeader("X-RapidAPI-Key", "cc450cdb9amsh0b1d69419475dd9p1b578ejsnc1c449292f91");
        //    request.AddHeader("X-RapidAPI-Host", "mega-fitness-calculator1.p.rapidapi.com");
        //    var response = client.Execute(request).Content;

        //    InfoBMR infoBMR = new InfoBMR();

        //    var formattedResponse = JObject.Parse(response)["info"];

        //    infoBMR.bmr = (double)formattedResponse["bmr"];

        //    infoBMR.gender = (string)formattedResponse["gender"];




        //    return infoBMR;
        //}
    }
}
