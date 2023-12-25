using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Numerics;
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
            Urunler urunler = new Urunler(); //urunler clasından yeni bir urun oluşturuyoruz
            Kategoriler kategoriler = new Kategoriler(); //kategoriler clasından yeni bir urun oluşturuyoruz


            Tuple<List<Urunler>, List<Kategoriler>> UrunKategoriTuple = new Tuple<List<Urunler>, List<Kategoriler>>
                (
                urunler.UrunGetir(),
                kategoriler.KategorilerGetir()
                );
            return View(UrunKategoriTuple);

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

            Kategoriler kategoriler = new Kategoriler();


            return View(kategoriler.KategorilerGetir());
        }
        public ActionResult KategoriActionEkle(string jsonInput)
        {
            JObject kategori = JsonConvert.DeserializeObject<JObject>(jsonInput);

            if (jsonInput != null)
            {
                Console.WriteLine(jsonInput);
                Kategoriler kategorireq = new Kategoriler();
                kategorireq.KategoriEkle(kategori["kategoriAdi"].ToString());
                
                AdminPanelKategori();
                return Json(new { success = true });

            }
            else
            {
                AdminPanelKategori();
                return Json(new { success = false });
            }
        }
        public ActionResult KategoriActionGuncelle(string jsonInput)
        {
            JObject kategori = JsonConvert.DeserializeObject<JObject>(jsonInput);

            if (jsonInput != null)
            {
                Console.WriteLine(jsonInput);
                Kategoriler kategorireq = new Kategoriler();
                kategorireq.KategoriGuncelle( Int32.Parse( kategori["kategoriId"].ToString()), kategori["kategoriAdi"].ToString());

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public ActionResult KategoriActionSil(string jsonInput)
        {
            JObject kategori = JsonConvert.DeserializeObject<JObject>(jsonInput);

            if (jsonInput != null)
            {
                Console.WriteLine(jsonInput);
                Kategoriler kategorireq = new Kategoriler();
                kategorireq.KategoriSil(Int32.Parse(kategori["kategoriId"].ToString()));

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
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

        public ActionResult UrunActionGuncelle(string jsonInput)
        {
            JObject urun = JsonConvert.DeserializeObject<JObject>(jsonInput);
            Console.WriteLine(urun);
            if (jsonInput != null)
            {
                Urunler urunreq = new Urunler();
                urunreq.UrunGuncelle(Int32.Parse(urun["urunId"].ToString()), urun["urunAdi"].ToString(), urun["urunAciklamasi"].ToString(), Int32.Parse(urun["kategoriID"].ToString()), decimal.Parse(urun["urunFiyati"].ToString()), urun["urunFotografi"].ToString());

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult UrunActionSil(string jsonInput)
        {
            JObject urun = JsonConvert.DeserializeObject<JObject>(jsonInput);
            Console.WriteLine(urun);
            if (jsonInput != null)
            {
                Urunler urunreq = new Urunler();
                urunreq.UrunSil(Int32.Parse(urun["urunId"].ToString()));

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult UrunAction(string jsonInput)
        {

            JObject urun = JsonConvert.DeserializeObject<JObject>(jsonInput);
            if (jsonInput != null)
            {

                Urunler urunreq = new Urunler();
                urunreq.UrunOlustur(urun["urunAdi"].ToString(), urun["urunAciklamasi"].ToString(), Int32.Parse(urun["kategoriID"].ToString()), decimal.Parse(urun["urunFiyati"].ToString()), urun["urunFotografi"].ToString());

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public IActionResult AdminPanelMasa()
        {
            Masalar masalar = new Masalar();

            return View(masalar.MasalarGetir());
        }

        public ActionResult MasaActionEkle(string jsonInput)
        {
            JObject masa = JsonConvert.DeserializeObject<JObject>(jsonInput);

            if (jsonInput != null)
            {
                Console.WriteLine(jsonInput);
                Masalar masareq = new Masalar();
                masareq.MasaEkle(masa["masaAdi"].ToString());

                AdminPanelMasa();
                return Json(new { success = true });

            }
            else
            {
                AdminPanelMasa();
                return Json(new { success = false });
            }
        }

        public ActionResult MasaActionGuncelle(string jsonInput)
        {
            JObject masa = JsonConvert.DeserializeObject<JObject>(jsonInput);

            if (jsonInput != null)
            {
                Console.WriteLine(jsonInput);
                Masalar masareq = new Masalar();
                masareq.MasaGuncelle(Int32.Parse(masa["masaId"].ToString()), masa["masaAdi"].ToString());

                AdminPanelMasa();

                return Json(new { success = true });
            }
            else
            {
                AdminPanelMasa();

                return Json(new { success = false });
            }
        }

        public ActionResult MasaActionSil(string jsonInput)
        {
            JObject masa = JsonConvert.DeserializeObject<JObject>(jsonInput);
            Console.WriteLine(masa);
            if (jsonInput != null)
            {
                Masalar masareq = new Masalar();
                masareq.MasaSil(Int32.Parse(masa["masaId"].ToString()));

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
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