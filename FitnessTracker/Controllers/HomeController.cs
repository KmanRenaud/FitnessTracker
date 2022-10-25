using FitnessTracker.FItnessAPI;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
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
            var connecter = new ClientConn();

            var updConnecter = connecter.HTTPBMIConn(root.weight, root.height);

            return View(updConnecter);
        }

    }
}