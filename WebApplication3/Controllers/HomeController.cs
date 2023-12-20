using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
using Newtonsoft.Json.Linq;

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

            Urunler urunler = new Urunler(); //urunler clasından yeni bir urun oluşturuyoruz
            Kategoriler kategoriler = new Kategoriler(); //kategoriler clasından yeni bir urun oluşturuyoruz


            Tuple<List<Urunler>, List<Kategoriler>> UrunKategoriTuple = new Tuple<List<Urunler>, List<Kategoriler>>
                (
                urunler.UrunGetir(),
                kategoriler.KategorilerGetir()
                );
            return View(UrunKategoriTuple);
        }
        [HttpPost]
        public ActionResult UrunAction(JObject jsonData)
        {

            Console.WriteLine("test");
            Console.WriteLine(jsonData);

            if (jsonData != null)
            {
                Console.WriteLine("veri geldi");
                Console.WriteLine(jsonData);


                //Urunler urun = new Urunler();
                //urun.UrunOlustur(model.UrunAdi.ToString(), model.UrunAciklamasi.ToString(), Convert.ToInt32(model.KategoriId), Convert.ToDecimal(model.UrunFiyat), model.UrunFotografi.ToString());


                return Json(new { success = true });
            }
            return Json(new { success = false });


        }

        public IActionResult AdminPanelMasa()
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