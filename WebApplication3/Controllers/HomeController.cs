using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult OrderPage()
        {
            return View();
        }
        public IActionResult ChefPage()
        {
            return View();
        }
        public IActionResult BarPage()
        {
            return View();
        }
        public IActionResult PaymentPage()
        {
            return View();
        }
        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult AdminPanelKategori()
        {
            return View();
        }
        public IActionResult AdminPanelUrun()
        {
            return View();
        }
        public IActionResult AdminPanelGunSonu()
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