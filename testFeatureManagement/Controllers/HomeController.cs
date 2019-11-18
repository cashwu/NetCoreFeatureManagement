using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace testFeatureManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManager _featureManager;

        public HomeController(ILogger<HomeController> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public IActionResult Index()
        {
            Console.WriteLine(_featureManager.IsEnabled("Beta"));
            return View();
        }

        [FeatureGate("Beta")]
        public IActionResult Feature()
        {
            return Content("Feature");
        }
    }
}