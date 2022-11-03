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

        private readonly string APIKey;


        public HomeController(ILogger<HomeController> logger, string aPIKey)
        {
            _logger = logger;
            APIKey = aPIKey;
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

            if (root.weight < 1)
            {
                root.weight = 1;
            }
            if (root.height < 1)
            {
                root.height = 1;
            }
            if (root.age < 1)
            {
                root.age = 1;
            }

            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bmi?weight={InfoBMI.ConvertWeightToKg(root.weight)}&height={InfoBMI.ConvertHeightToCm(root.height)}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", APIKey);
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

        //public IActionResult ConvertKgLbs(Root root)
        //{

        //    double kilos = Convert.ToDouble(root.Kgs);

        //    kilos *= 2.205;

        //    KgsToPounds finalCon = new KgsToPounds();

        //    finalCon.KgsAreLbs = kilos;

        //    return View(finalCon);

        //}
        public IActionResult CallBmrAPI(Root root)
        {
            if (root.weight < 1)
            {
                root.weight = 1;
            }
            if (root.height < 1)
            {
                root.height = 1;
            }
            if (root.age < 1)
            {
                root.age = 1;
            }

            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bmr?weight={InfoBMI.ConvertWeightToKg(root.weight)}&height={InfoBMI.ConvertHeightToCm(root.height)}&age={root.age}&gender={root.gender}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", APIKey);
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
            if (root.weight < 1)
            {
                root.weight = 1;
            }
            if (root.height < 1)
            {
                root.height = 1;
            }
            if (root.age < 1)
            {
                root.age = 1;
            }

            var client = new RestClient($"https://mega-fitness-calculator1.p.rapidapi.com/bfp?weight={InfoBMI.ConvertWeightToKg(root.weight)}&height={InfoBMI.ConvertHeightToCm(root.height)}&age={root.age}&gender={root.gender}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", APIKey);
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