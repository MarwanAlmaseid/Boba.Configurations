using Boba.Configurations.Web.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Boba.Configurations.Web.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailConfig _emailConfig;
        public HomeController(ILogger<HomeController> logger,
            EmailConfig emailConfig)
        {
            _logger = logger;
            _emailConfig = emailConfig;
        }

        public IActionResult Index()
        {
            var defaultEmail = _emailConfig.DefaultFromEmail;
            return View();
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
    }
}
