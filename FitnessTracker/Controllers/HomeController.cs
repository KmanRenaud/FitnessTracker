using FitnessTracker.FItnessAPI;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var root = new Root();
            return View(root);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult CallBmiAPI(Root root)
        {
            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bmi?weight={root.weight}&height={root.height}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "cc450cdb9amsh0b1d69419475dd9p1b578ejsnc1c449292f91");
            request.AddHeader("X-RapidAPI-Host", "mega-fitness-calculator1.p.rapidapi.com");
            var response = client.Execute(request).Content;

            InfoBMI infoBMI = new InfoBMI();

            var formattedResponse = JObject.Parse(response)["info"];

            infoBMI.bmi = (double)formattedResponse["bmi"];

            infoBMI.health = (string)formattedResponse["health"];

            infoBMI.healthy_bmi_range = (string)formattedResponse["healthy_bmi_range"];



            var updConnecter = infoBMI;

            return View(updConnecter);
        }
        public IActionResult CallBmrAPI(Root root)
        {
            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bmr?weight={root.weight}&height={root.height}&age={root.age}&gender={root.gender}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "cc450cdb9amsh0b1d69419475dd9p1b578ejsnc1c449292f91");
            request.AddHeader("X-RapidAPI-Host", "mega-fitness-calculator1.p.rapidapi.com");
            var response = client.Execute(request).Content;

            InfoBMR infoBMR = new InfoBMR();

            var formattedResponse = JObject.Parse(response)["info"];

            infoBMR.bmr = (double)formattedResponse["bmr"];

            infoBMR.gender = (string)formattedResponse["gender"];



            var updConnecter = infoBMR;

            return View(updConnecter);
        }
        public IActionResult CallBfpAPI(Root root)
        {

            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bfp?weight={root.weight}&height={root.height}&age={root.age}&gender={root.gender}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "cc450cdb9amsh0b1d69419475dd9p1b578ejsnc1c449292f91");
            request.AddHeader("X-RapidAPI-Host", "mega-fitness-calculator1.p.rapidapi.com");
            var response = client.Execute(request).Content;

            InfoBFP infoBFP = new InfoBFP();

            var formattedResponse = JObject.Parse(response)["info"];

            infoBFP.bfp = (double)formattedResponse["bfp"];

            infoBFP.gender = (string)formattedResponse["gender"];
            
            infoBFP.fat_mass = (double)formattedResponse["fat_mass"];
            
            infoBFP.lean_mass = (double)formattedResponse["lean_mass"];

            infoBFP.description = (string)formattedResponse["description"];



            var updConnecter = infoBFP;

            return View(updConnecter);
        }

    }
}